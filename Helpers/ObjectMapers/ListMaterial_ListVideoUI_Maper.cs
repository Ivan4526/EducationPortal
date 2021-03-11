using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class ListMaterial_ListVideoUI_Maper : IMaper<List<Material>, List<VideoUI>>
    {
        IMaper<Video, VideoUI> videoMaper;
        public ListMaterial_ListVideoUI_Maper(IMaper<Video, VideoUI> videoMaper)
        {
            this.videoMaper = videoMaper;
        }
        public List<VideoUI> Map(List<Material> materials)
        {
            var videos = new List<VideoUI>();
            foreach (var material in materials)
            {
                videos.Add(videoMaper.Map(material.Video));
            }
            return videos;
        }
    }
}
