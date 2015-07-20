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
        }

        VkApi vk = new VkApi();
        System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.Group> groupsList;
        VkNet.Model.Group group;
        System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.Attachments.Audio> audiosList;
        System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.AudioAlbum> albumsList;
        int albumsCount = 0;

        private void enterBut_Click(object sender, EventArgs e)
        {
            try
            {
                Settings scope = Settings.Groups;
                scope = Settings.Audio;
                vk.Authorize(4919033, userText.Text, passText.Text, scope);
                var user = vk.Users.Get((long)vk.UserId, null, null);

                groupsList = vk.Groups.Get(user.Id, true, GroupsFilters.Moderator);
                foreach (var item in groupsList)
                    groupsListBox.Items.Add(item.Name);
                groupsListBox.Enabled = true;
                enterLabel.Text = "Успешный вход";
            }
            catch
            {
                enterLabel.Text = "Неправильный логин/пароль";
            }
        }

        private void groupsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (albumsListBox.Items.Count != 0)
                    foreach (var item in albumsList)
                        albumsListBox.Items.Remove(item.Title);
                group = vk.Groups.GetById(groupsList[groupsListBox.SelectedIndex].Id, null);
                audiosList = vk.Audio.GetFromGroup((long)group.Id, null, null, 0, 0);
                albumsList = vk.Audio.GetAlbums(-group.Id, null, 0);
                foreach (var item in albumsList)
                    albumsListBox.Items.Add(item.Title);
                albumsListBox.Enabled = true;
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
                foreach (var item in albumsList)
                    albumsListBox.Items.Remove(item.Title);

                albumsCount += 50;
                albumsList = new System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.AudioAlbum>(vk.Audio.GetAlbums(-group.Id, null, albumsCount));
                if (albumsList.Count != 50) 
                    next50.Enabled = false;
                prev50.Enabled = true;

                
                foreach (var item in albumsList)
                    albumsListBox.Items.Add(item.Title);
            }
            catch
            {
                MessageBox.Show("Больше нет альбомов");
            }
        }

        private void prev50_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in albumsList)
                    albumsListBox.Items.Remove(item.Title);

                albumsCount -= 50;
                albumsList = new System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.AudioAlbum>(vk.Audio.GetAlbums(-group.Id, null, albumsCount));
                if (albumsCount == 0)
                    prev50.Enabled = false;
                if (albumsList.Count == 50) 
                    next50.Enabled = true;

                foreach (var item in albumsList)
                    albumsListBox.Items.Add(item.Title);
            }
            catch
            {
                MessageBox.Show("Меньше нет альбомов");
            }
        }

        private void albumsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            up.Enabled = true;
        }

        private void up_Click(object sender, EventArgs e)
        {
            
            try
            {
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
                var audioGroupAlbum = vk.Audio.GetFromGroup((long)group.Id,
                    urlidCheckBox.Checked ?
                    a
                    : Convert.ToInt32(albumsList[albumsListBox.SelectedIndex].AlbumId), 
                    null, 0, 0);
                if (audioGroupAlbum[0].Id == audiosList[0].Id)
                {
                    MessageBox.Show("Альбом и так первый");
                    return;
                }
                for (int j = 0; j < audioGroupAlbum.Count(); j++)
                    vk.Audio.Reorder(audioGroupAlbum[j].Id, -(long)group.Id, 0, audiosList[0].Id);
                audiosList = vk.Audio.GetFromGroup((long)group.Id, null, null, 0, 0);
                MessageBox.Show("Альбом поднят");
            }
            catch
            {
                MessageBox.Show("Невозможно поднять альбом");
            }
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
                if(albumsListBox.SelectedItem == null) up.Enabled = false;
            }
        }
    }
}
