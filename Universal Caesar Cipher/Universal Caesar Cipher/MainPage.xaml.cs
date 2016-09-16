using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Universal_Caesar_Cipher
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Encode.Click += encode;
            Decode.Click += decode;
        }

        public void encode(object o, RoutedEventArgs a)
        {
            string text = Input.Text;
            try
            {
                int offset = int.Parse(Offset.Text);
                offset = offset % 26;
                Caesar caesar = new Caesar { Input = text, Offset = offset };
                text = caesar.Encode();
                Input.Text = text;
            } catch {
                Debug.WriteLine("Please enter a number for an offset");
            }
        }

        public void decode(object o, RoutedEventArgs a)
        {
            string text = Input.Text;
            try
            {
                int offset = int.Parse(Offset.Text);
                offset = offset % 26;
                Caesar caesar = new Caesar { Input = text, Offset = offset };
                text = caesar.Decode();
                Input.Text = text;
            }
            catch
            {
                Debug.WriteLine("Please enter a number for an offset");
            }
        }
    }
}
