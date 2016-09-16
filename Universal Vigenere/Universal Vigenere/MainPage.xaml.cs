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

namespace Universal_Vigenere
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

        public void encode(object o, RoutedEventArgs e)
        {
            string input = Textbox.Text;
            string key = Key.Text;
            Debug.WriteLine("Input = {0}, Key = {1}", input, key);
            Vigenere cipher = new Vigenere { Input = input };
            cipher.SetKey(key);
            Debug.WriteLine("");
            string output = cipher.Encode();
            Textbox.Text = output;
        }

        public void decode(object o, RoutedEventArgs e)
        {
            string input = Textbox.Text;
            string key = Key.Text;
            Debug.WriteLine("Input = {0}, Key = {1}", input, key);
            Vigenere cipher = new Vigenere { Input = input };
            cipher.SetKey(key);
            Debug.WriteLine("");
            string output = cipher.Decode();
            Textbox.Text = output;
        }
    }
}
