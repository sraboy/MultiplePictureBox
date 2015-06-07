using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MultiplePictureBox
{
    public partial class MultiplePictureBox : UserControl
    {
        private int imagecount;
        private int displayimage = 0;
        public Image[] images;

        public int ImageCount
        {
            get
            {
                return this.imagecount;
            }
            set
            {
                this.imagecount = value;
            }
        }

        public MultiplePictureBox()
        {
            InitializeComponent();
        }

        public void Initialize(string[] filenames)
        {
            ImageCount = filenames.Count();
            images = new Image[ImageCount];

            for (int x = 0; x < imagecount; x++)
            {
                images[x] = Image.FromFile(filenames[x]);
            }
        }

        #region AddImage() - DEPRECATED
        /// <summary>
        /// DEPRECATED - Adds another image to the array
        /// </summary>
        /// <param name="image">The Image object to add to the array</param>
        public bool AddImage(Image image)
        {
            int x = 0;

            //Cycles through the array to find an empty slot for the new image
            while (images[x] != null)
            {
                if (x < imagecount)
                {
                    x++;
                    if (images[x] == null)
                    {
                        images[x] = image;
                        return true;
                    }
                }
                else
                    return false;
            }

            images[x] = image;
            return true;
        }
        #endregion

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (displayimage < imagecount)
            {
                displayimage++;
                if (displayimage == imagecount)
                    displayimage = 0;


                ImageContainer.Image = images[displayimage];
            }
            else
                displayimage = 0;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
                if (displayimage > 0)
                {
                    displayimage--;
                    if (displayimage == -1)
                        displayimage = imagecount;

                    ImageContainer.Image = images[displayimage];
                }
                else if (displayimage == 0)
                {
                    displayimage = (imagecount - 1);
                    ImageContainer.Image = images[displayimage];
                }
        }
    }
}
