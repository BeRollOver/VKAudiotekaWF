using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Enums.Filters;

namespace VKAudiotekaWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            scope = Settings.Audio;
        }

        VkApi vk = new VkApi();
        Settings scope;
        VkNet.Model.User user;
        System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.Group> groupsList;
        VkNet.Model.Group group;
        System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.Attachments.Audio> audiosList;
        System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.AudioAlbum> albumsList;
        int albumsCount = 0;

        private void enterBut_Click(object sender, EventArgs e)
        {
            try
            {
                // Заходим в ВК
                vk.Authorize(4919033, userText.Text, passText.Text, scope);
                user = vk.Users.Get((long)vk.UserId, null, null);
                enterLabel.Text = "Успешный вход";

                // Получаем список собственных аудиозаписей и альбомов
                audiosList = vk.Audio.Get(user.Id, null, null, null, null);
                albumsList = vk.Audio.GetAlbums(user.Id, null, 0);
                foreach (var item in albumsList)
                    albumsListBox.Items.Add(item.Title);
                albumsListBox.Enabled = true;

                // Получаем инфу о группах
                groupsList = vk.Groups.Get(user.Id, true, GroupsFilters.Moderator);
                foreach (var item in groupsList)
                    groupsListBox.Items.Add(item.Name);

                // Включаем все нужные кнопки
                groupsListBox.Enabled = true;
            }
            catch (VkNet.Exception.VkApiAuthorizationException)
            {
                enterLabel.Text = "Неправильный логин/пароль";
            }
            catch (VkNet.Exception.VkApiException)
            {
                MessageBox.Show("Сбой со стороны ВКонтакте");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так, пните Митю!");
            }
        }

        private void groupsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // После выбора группы чистим лист с альбомами от предыдущей группы
                if (albumsListBox.Items.Count != 0)
                    foreach (var item in albumsList)
                        albumsListBox.Items.Remove(item.Title);

                // Выбираем нужную группу, получаем список всех аудиозаписей и альбомов, выводим его
                group = vk.Groups.GetById(groupsList[groupsListBox.SelectedIndex].Id, null);
                audiosList = vk.Audio.GetFromGroup(group.Id, null, null, 0, 0);
                albumsList = vk.Audio.GetAlbums(-group.Id, null, 0);
                foreach (var item in albumsList)
                    albumsListBox.Items.Add(item.Title);
                
                // Включаем все нужные кнопки
                if (albumsList.Count == 50) next50.Enabled = true;
                urlidCheckBox.Enabled = true;
            }
            catch (VkNet.Exception.AccessDeniedException)
            {
                MessageBox.Show("В группе нет аудиозаписей");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так, пните Митю!");
            }
        }

        private void next50_Click(object sender, EventArgs e)
        {
            try
            {
                // Удаляем все альбомы из списка перед обновлением
                foreach (var item in albumsList)
                    albumsListBox.Items.Remove(item.Title);

                // Получаем новые 50 альбомов
                albumsCount += 50;
                albumsList = new System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.AudioAlbum>(vk.Audio.GetAlbums(-group.Id, null, albumsCount));

                // Добавляем новые альбомы в список
                foreach (var item in albumsList)
                    albumsListBox.Items.Add(item.Title);

                // Врубаем все нужные кнопки
                if (albumsList.Count != 50) 
                    next50.Enabled = false;
                prev50.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Альбомов больше нет");
            }
        }

        private void prev50_Click(object sender, EventArgs e)
        {
            try
            {
                // Удаляем все альбомы из списка перед обновлением
                foreach (var item in albumsList)
                    albumsListBox.Items.Remove(item.Title);

                // Получаем предыдущие 50 альбомов
                albumsCount -= 50;
                albumsList = new System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.AudioAlbum>(vk.Audio.GetAlbums(-group.Id, null, albumsCount));

                // Добавляем полученные альбомы в список
                foreach (var item in albumsList)
                    albumsListBox.Items.Add(item.Title); 
                
                // Врубаем нужные кнопки
                if (albumsCount == 0) prev50.Enabled = false;
                if (albumsList.Count == 50) next50.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Меньше нет альбомов");
            }
        }

        // Активизирует конпку Поднять при выборе альбома
        private void albumsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            up.Enabled = true;
        }

        // По URL и ID
        private void urlidCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (urlidCheckBox.Checked)
            {
                albumsListBox.Enabled = false;
                urlidTextBox.Visible = true;
                up.Enabled = true;
            }
            else
            {
                albumsListBox.Enabled = true;
                urlidTextBox.Visible = false;
                if (albumsListBox.SelectedItem == null) up.Enabled = false;
            }
        }

        private void up_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Для URL/ID
                int a = 0;
                try
                {
                    if(urlidCheckBox.Checked) a = Convert.ToInt32(urlidTextBox.Text);
                }
                catch (FormatException)
                {
                    a = Convert.ToInt32(urlidTextBox.Text.Remove(0, urlidTextBox.Text.LastIndexOf("=") + 1));
                }
                catch
                {
                    MessageBox.Show("Неправильный URL/ID");
                }


                // Поднимает указанный альбом на самый верх
                var audioGroupAlbum = (group != null) ? // Определяет, вызывать метод пользователя или группы
                    vk.Audio.GetFromGroup(group.Id,
                    urlidCheckBox.Checked ? a : Convert.ToInt32(albumsList[albumsListBox.SelectedIndex].AlbumId), //Определяет, брать альбом из списка или из textbox
                    null, 0, 0) : 
                vk.Audio.Get(user.Id, Convert.ToInt32(albumsList[albumsListBox.SelectedIndex].AlbumId), null, null, null);

                // Лучше не двигать альбом, если он первый
                if (audioGroupAlbum[0].Id == audiosList[0].Id)
                {
                    MessageBox.Show("Альбом и так первый");
                    return;
                }

                // Поднимаем
                for (int j = 0; j < audioGroupAlbum.Count(); j++)
                    vk.Audio.Reorder(audioGroupAlbum[j].Id, group != null ? - group.Id : user.Id, 0, audiosList[0].Id);

                // Получаем новый список аудизаписей с новый порядком 
                audiosList = group != null ?
                    vk.Audio.GetFromGroup(group.Id, null, null, 0, 0) :
                    vk.Audio.Get(user.Id, null, null, null, null);
                MessageBox.Show("Альбом поднят");
            }
            catch
            {
                MessageBox.Show("Невозможно поднять альбом");
            }
        }
    }
}
