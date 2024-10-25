using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ula22._10._24
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using System;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;

    public partial class MainWindow : Window
    {
        static string ResourceLink = @"C:\Users\новий_користувач\OneDrive\Робочий стіл\obrazy\";

        public MainWindow()
        {
            InitializeComponent();
            LoadImagesToComboBox();

            cbbImages.SelectionChanged += CbbImages_SelectionChanged;

            btnGoLeft.Click += BtnGoLeft_Click;
            btnGoRight.Click += BtnGoRight_Click;
        }

        private void LoadImagesToComboBox()
        {
            try
            {
                var imageFiles = Directory.GetFiles(ResourceLink, "*.*")
                                          .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".bmp"))
                                          .ToList();

                cbbImages.ItemsSource = imageFiles;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CbbImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbbImages.SelectedItem != null)
            {
                string selectedImagePath = cbbImages.SelectedItem.ToString();
                DisplayImage(selectedImagePath);
            }
        }

        private void DisplayImage(string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();
            imgDisplay.Source = bitmap;
        }

        private void BtnGoLeft_Click(object sender, RoutedEventArgs e)
        {
            if (cbbImages.Items.Count > 0 && cbbImages.SelectedIndex > 0)
            {
                cbbImages.SelectedIndex--;
            }
        }

        private void BtnGoRight_Click(object sender, RoutedEventArgs e)
        {
            if (cbbImages.Items.Count > 0 && cbbImages.SelectedIndex < cbbImages.Items.Count - 1)
            {
                cbbImages.SelectedIndex++;
            }
        }
    }

}