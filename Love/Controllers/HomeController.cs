using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace ValentineApp.Controllers
{
    // Keeping this outside the HomeController class fixes the CS0234 error
    public class LoveMessage
    {
        public string Text { get; set; }
        public string Img { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.AnniversaryDate = new DateTime(2020, 9, 10);

            // Key = Image Filename, Value = Your Custom Message
            var galleryData = new Dictionary<string, string>
    {
        { "lick.jpg", "Sarap mo" },
        { "flower.jpg", "Syempre mahal kita eh" },
        { "1stmirror.jpg", "Angas talaga natin" },
        { "Mirror.jpg", "Diba isa pa" },
        { "maroon.jpg", "totoy at nene pa tayo dito" },
        { "forest.jpg", "Di'ba nature lover" },
        { "back2back.jpg", "Parang Agent" },
        { "White.jpg", "Parang Agent" },
        { "kneel.jpg", "will you marry be my forever?" }
    };

            return View(galleryData);
        }

        public ActionResult Gallery()
        {
            string folderPath = Server.MapPath("~/Content/Images/");
            var images = Directory.GetFiles(folderPath)
                          .Select(f => "/Content/Images/" + Path.GetFileName(f)).ToList();
            return View(images);
        }

        public ActionResult Messages()
        {
            var messages = new List<LoveMessage>
            {
                new LoveMessage { Text = "Happy Valentine's my love, ganda mo talaga", Img = "/Content/Images/Valentin'es 2.jpg" },
                new LoveMessage { Text = "So love,love,love,love", Img = "/Content/Images/Valentine's.jpg" },
                new LoveMessage { Text = "So Happy That we're able to finish 12 months taking a photobooth", Img = "/Content/Images/4 pics.jpg" },
                new LoveMessage { Text = "Every moment is golden", Img = "/Content/Images/chair.jpg" },
                 new LoveMessage { Text = "Wishing more moment with you", Img = "/Content/Images/kneel.jpg" },
                  new LoveMessage { Text = "I love you so much", Img = "/Content/Images/baloon.jpg" },
                   new LoveMessage { Text = "Soafeer beautiful", Img = "/Content/Images/beautyy.jpg" }
            };
            return View(messages);
        }
    }
}