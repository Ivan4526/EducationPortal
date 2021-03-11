using Models;
using Models.UI;
using ModelsUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IMaper<TSource, TDestination> where TSource : class where TDestination : class
    {
        TDestination Map(TSource source);
        // Course MapCourseUI_CourseRepo(CourseUI courseUI);
        //BookUI MapBookRepoToUI(Book bookRepo);
    }
}
