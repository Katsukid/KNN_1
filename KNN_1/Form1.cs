using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using Newtonsoft.Json;
namespace KNN_1
{
     public partial class Form1 : Form
     {
          private Bitmap img;
          private Dictionary<string, List<List<int>>> patterns;
          private int K;
          private string folder = @"G:\Desktop\Ky2nam5\DataMining\KNN_Number_Data\"; // Sua dong nay
          //private bool initedData = false;
          private int scaleW = 3;
          private int scaleH = 5;
          private int resizeW = 300;
          private int resizeH = 500;
          private string fileData = "data.txt"; // Du lieu se tao ra 1 lan, neu them anh thi phai tim va xoa file nay di, chua lam phan tu dong
          public Form1()
          {
               InitializeComponent();
               patterns = prepareData(folder);
               K = 7;
          }
          private void btnOpen_Click(object sender, EventArgs e)
          {
               // open file dialog   
               OpenFileDialog open = new OpenFileDialog();
               // image filters  
               open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
               if (open.ShowDialog() == DialogResult.OK)
               {
                    
                    // display image in picture box
                    img = new Bitmap(open.FileName);                  
                    ptbx.Image = img;
                    // image file path
                    txtbImage.Text = open.FileName;
               }    
          }

          private void btnCheck_Click(object sender, EventArgs e)
          {
               int[] knn = new int[10];
               // Tim khung bao
               string background = "ffffffff";
               int top, bot, right, left;
               findOutline(img, background, out top, out bot, out left, out right);
               var newImg = resizeImage(cropImage(img, top, bot, left, right), 300, 500);
               ptbx.Image = newImg;
               var target = countPixels(newImg, "ffffffff", scaleW, scaleH);
               int i = 0;
               Dictionary<string, double> result = new Dictionary<string, double>();
               foreach (var k in patterns.Keys)
               {
                    foreach (var p in patterns[k])
                    {
                         i++;
                         var x = distance(target, p);
                         result.Add(k + "-" +i.ToString(),x);
                    }
               }
               var temp = result.OrderBy(u => u.Value).ToDictionary(x => x.Key, y => y.Value).Take(K).ToList();
               for(int c = 0; c < K; c++)
               {
                    var key = int.Parse(temp[c].Key.Split('-')[0]);
                    knn[key]++;
               }
               int max = 0;
               int number = 10;
               for(int t = 0; t <= 9;t++)
               {
                    if(knn[t] > max)
                    {
                         max = knn[t];
                         number = t;
                    }
               }
               if (number == 10) number = knn[0];
               lbResult.Text = number.ToString();
          }
          // Find outline
          public void findOutline(Bitmap img,string background,out int top, out int bot, out int left, out int right)
          {
               top = bot = left = right = 0;
               bool check = false;
               // Tim diem trai
               for (int i = 0; i < img.Width; i++)
               {
                    for (int j = 0; j < img.Height; j++)
                    {
                         Color pixel = img.GetPixel(i, j);
                         if (pixel.Name != background)
                         {
                              left = i;
                              check = true;
                              break;
                         }
                    }
                    if (check)
                    {
                         break;
                    }
               }
               // Tim diem phai
               check = false;
               for (int i = img.Width - 1; i >= 0; i--)
               {
                    for (int j = 0; j < img.Height; j++)
                    {
                         Color pixel = img.GetPixel(i, j);
                         if (pixel.Name != background)
                         {
                              right = i;
                              check = true;
                              break;
                         }
                    }
                    if (check)
                    {
                         break;
                    }
               }
               // Tim diem tren
               check = false;
               for (int j = 0; j < img.Height; j++)
               {
                    for (int i = 0; i < img.Width; i++)
                    {
                         Color pixel = img.GetPixel(i, j);
                         if (pixel.Name != background)
                         {
                              top = j;
                              check = true;
                              break;
                         }
                    }
                    if (check)
                    {
                         break;
                    }
               }
               // Tim diem duoi
               check = false;
               for (int j = img.Height - 1; j >= 0; j--)
               {
                    for (int i = 0; i < img.Width; i++)
                    {
                         Color pixel = img.GetPixel(i, j);
                         if (pixel.Name != background)
                         {
                              bot = j;
                              check = true;
                              break;
                         }
                    }
                    if (check)
                    {
                         break;
                    }
               }
          }
          // Cat anh
          private Bitmap cropImage(Bitmap img, int top, int bot, int left, int right)
          {
               Rectangle cropRect = new Rectangle(left, top, (right - left), (bot - top));
               Bitmap src = img;
               Bitmap cropped = new Bitmap(cropRect.Width, cropRect.Height);

               using (Graphics g = Graphics.FromImage(cropped))
               {
                    g.DrawImage(src, new Rectangle(0, 0, cropped.Width, cropped.Height),
                                     cropRect,
                                     GraphicsUnit.Pixel);
               }
               return cropped;
          }
          // Resize
          public Bitmap resizeImage(Bitmap img, int width, int height)
          {
               Bitmap b = new Bitmap(width, height);
               Graphics g = Graphics.FromImage(b);

               g.DrawImage(img, 0, 0, width, height);
               g.Dispose();

               return b;
          }
          // Find Features
          public List<int> countPixels(Bitmap img, string background, int scaleW, int scaleH)
          {
               List<int> temp = new List<int>();
               int count;
               int rangeW = img.Width / scaleW;
               int rangeH = img.Height / scaleH;
               for (int rh = 0; rh < scaleH; rh++)
               {
                    for (int rw = 0; rw < scaleW; rw++)
                    {
                         count = 0;
                         for (int i = rangeW * rw; i < rangeW * (rw + 1); i++)
                         {
                              for (int j = rangeH * rh; j < rangeH * (rh + 1); j++)
                              {
                                   Color pixel = img.GetPixel(i, j);
                                   if (pixel.Name != background)
                                   {
                                        count++;
                                   }
                              }
                         }
                         temp.Add(count);
                    }
               }
               return temp;
          }
          // Prepare Data for KNN
          public Dictionary<string, List<List<int>>> prepareData(string folder)
          {
               if (File.Exists(folder + fileData)) return readPatterns(fileData);
               string[] listNumber = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
               var background = "ffffffff";
               int top, bot, left, right;
               Dictionary<string, List<List<int>>> patterns = new Dictionary<string, List<List<int>>>();
               List<List<int>> datas;
               foreach(var s in listNumber)
               {
                    datas = new List<List<int>>();
                    string[] filePaths = Directory.GetFiles(folder + "\\" + s);
                    if (filePaths.Length == 0) continue;
                    foreach(var f in filePaths)
                    {
                         Bitmap img = new Bitmap(Image.FromFile(f));
                         findOutline(img, background, out top, out bot, out left, out right);
                         var newImg = resizeImage(cropImage(img, top, bot, left, right), resizeW, resizeH);
                         datas.Add(countPixels(newImg, background, scaleW, scaleH));
                    }
                    patterns.Add(s, datas);
               }
               storePatterns(patterns, folder + fileData);
               return patterns;
          }
          // Distance
          public double distance(List<int> target,List<int> pattern)
          {
               int len = target.Count;
               int sum = 0;
               for(int i = 0; i < len; i++)
               {
                    sum = target[i] - pattern[i];                    
               }
               return Math.Sqrt(Math.Pow(sum, 2));
          }
          // Store patterns to file
          public void storePatterns(Dictionary<string, List<List<int>>> dictionary, string fileName)
          {
               using (StreamWriter file = new StreamWriter(fileName))
                         file.WriteLine(JsonConvert.SerializeObject(dictionary));
          }
          // Read patterns from file
          public Dictionary<string, List<List<int>>> readPatterns(string fileName)
          {
               using (StreamReader file = new StreamReader(folder + fileName))
                    return JsonConvert.DeserializeObject< Dictionary<string, List<List<int>>>>(file.ReadToEnd());
          }

     }
}
