using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Properties;

namespace SecretMessageGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath) ;
            string pdfPath = strWorkPath + "\\SecretMessage.pdf";

            List<string> lines = new List<string>();
            string[] words = textBox1.Text.Replace("\n", " ").Split(' ');

            string currentString = "";
            int stringCount = 0;
            // 19 seems to be a good number for our pdf size for each line
            int maxStringCount = 19;
            int wordCount = 0;
            int maxWordCount = words.Length;
            bool tooLongOfWord = false;

            // loop over each word and assign it into a string of works
            // these will make up our lines
            foreach(string word in words)
            {
                if(stringCount == 0)
                {
                    stringCount = word.Length;
                    currentString = word;
                    wordCount++;
                }
                // add word to current string
                else if((stringCount + word.Length + 1) <= maxStringCount)
                {
                    currentString = currentString + " " + word;
                    stringCount = stringCount + word.Length + 1;
                    wordCount++;
                }
                // we can't add the current word as it is too long
                else
                {
                    tooLongOfWord = true;
                    wordCount++;
                }

                // we have reached the end of a row (exact length), the current word is too long or we have reached the end of our words
                if ((stringCount == maxStringCount) || (tooLongOfWord) || (wordCount == maxWordCount))
                {
                    lines.Add(currentString);
                    currentString = "";
                    stringCount = 0;

                    // we haven't added our current word, we must add it to the new string 
                    if (tooLongOfWord)
                    {
                        stringCount = word.Length;
                        currentString = word;
                        tooLongOfWord = false;

                        // last word is too long for the current line, we add it to one final line
                        if(wordCount == maxWordCount)
                        {
                            lines.Add(currentString);
                        }
                    }
                }
            }

            // sanity check....
            foreach(string words1 in lines)
            {
                Console.WriteLine(words1);
            }

            // create our pdf doc
            PdfWriter writer = new PdfWriter(pdfPath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            pdf.SetDefaultPageSize(new iText.Kernel.Geom.PageSize(1063 , 1375));

            int currentX = 50;
            int currentY = 50;
            int currentStringPrinting = (lines.Count - 1);
            int currentLetterPrinting = 0;

            // loop over all lines, printing the pic that is assigned to it to the pdf as we go
            // note ! we go in reverse order to ensure the pdf is in order as we are adding images !!
            while (true)
            {   
                // we have reached the end of a line and need to move on to the next one
                if(currentLetterPrinting == lines[currentStringPrinting].Length)
                {
                    currentStringPrinting--;
                    currentLetterPrinting = 0;
                    currentY += 100;
                    currentX = 50;
                }

                // we have reached the end of our strings
                if (currentStringPrinting == -1)
                {
                    break;
                }

                // switch on current letter to get correct img
                iText.Layout.Element.Image img;
                string currentLetter = lines[currentStringPrinting][currentLetterPrinting].ToString().ToLower();
                switch (currentLetter)
                {
                    case "a":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\a.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "b":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\b.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "c":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\c.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "d":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\d.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "e":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\e.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "f":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\f.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "g":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\g.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "h":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\h.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "i":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\i.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "j":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\j.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "k":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\k.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "l":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\l.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "m":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\m.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "n":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\n.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "o":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\o.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "p":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\p.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "q":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\q.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "r":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\r.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "s":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\s.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "t":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\t.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "u":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\u.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "v":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\v.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "w":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\w.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "x":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\x.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "y":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\y.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "z":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\z.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case ".":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\dot.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case "!":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\exp.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    case " ":
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\spc.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }

                    default:
                        {
                            img = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\spc.PNG")).SetTextAlignment(TextAlignment.CENTER);
                            break;
                        }
                }

                // move on to next letter when we go through another round
                currentLetterPrinting++;

                // set the position of the img in the pdf and set its height / width
                img.SetFixedPosition(currentX, currentY);
                img.SetHeight(50);
                img.SetWidth(50);
                document.Add(img);

                // inc x for next img
                currentX += 50;
            }

            // add key to the pdf
            iText.Layout.Element.Image img2 = new iText.Layout.Element.Image(ImageDataFactory.Create(strWorkPath + "\\photos\\key.PNG")).SetTextAlignment(TextAlignment.CENTER);
            document.Add(img2);
            Console.WriteLine("All Done");
            document.Close();
            textBox3.Text = pdfPath;
        }
    }
}
