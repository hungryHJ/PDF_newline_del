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

namespace PDF_newline_del
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rich_input_TextChanged(object sender, TextChangedEventArgs e)
        {
            string tmp = StringFromRichTextBox(rich_input);
            tmp = tmp.Replace(".\r\n",  ((char)1).ToString());
            tmp = tmp.Replace("\r\n", " ");
            tmp = tmp.Replace(((char)1).ToString(), ".\r\n\r\n");
            //tmp = tmp.Replace("\r", " ");
            //tmp = tmp.Replace("\n", " ");
            //tmp = tmp.Replace("   ", "\r\n");
            if (rich_output != null)
            {
                rich_output.Document.Blocks.Clear();
                rich_output.Document.Blocks.Add(new Paragraph(new Run(tmp)));
            }
            if (btn_cpy != null)
            {
                btn_cpy.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDDDDDD"));
                btn_cpy.Content = "Copy to Clip board";
            }
            

        }

        string StringFromRichTextBox(RichTextBox rtb)
        {

            TextRange textRange = new TextRange

            (rtb.Document.ContentStart, rtb.Document.ContentEnd);



            if (textRange.Text.Equals("\r\n"))

                return string.Empty;



            return textRange.Text;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(StringFromRichTextBox(rich_output));
            btn_cpy.Background = new SolidColorBrush(Colors.Green);
            btn_cpy.Content = "Copied!";
        }
    }
}