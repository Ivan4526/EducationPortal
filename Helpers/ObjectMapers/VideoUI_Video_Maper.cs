using Interfaces;
using Models;
using Models.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.ObjectMapers
{
    public class VideoUI_Video_Maper : IMaper<VideoUI, Video>
    {
        public Video Map(VideoUI videoUI)
        {
            var videoRepo = new Video();
            videoRepo.Id = Convert.ToInt32(videoUI.Id);
            videoRepo.MaterialId = Convert.ToInt32(videoUI.MaterialId);
            videoRepo.Duration = videoUI.Duration; 
            videoRepo.Quality = videoUI.Quality;
            videoRepo.Name = videoUI.Name;
            return videoRepo;

        }
    }
}
