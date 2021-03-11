using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class Video_VideoUI_Maper : IMaper<Video, VideoUI>
    {
        public VideoUI Map(Video videoRepo)
        {
            if (videoRepo == null)
                return null;
            var videoUI = new VideoUI();
            //videoUI.MaterialTypeId = videoRepo.Material.MaterialTypeId;
            videoUI.Id = videoRepo.Id;
            videoUI.MaterialId = videoRepo.MaterialId;
            videoUI.Name = videoRepo.Name;
            videoUI.Duration = videoRepo.Duration;
            videoUI.Quality = videoRepo.Quality;
            return videoUI;
        }
    }
}
