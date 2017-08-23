using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Common.ProjectHelpers
{
    public static class DirectoryPath
    {
        private static string BasePath = "media/";

        public static string Course(int id)
        {
            return string.Format(
                BasePath + "courses/{0}/", id
            );
        }

        public static string CourseAttachments(int id)
        {
            return string.Format(
                BasePath + "courses/{0}/attachments/", id
            );
        }

        public static string CollegeFile(DateTime date)
        {
            return string.Format(
                BasePath + "college/{0}", date.Year.ToString()
            );
        }

        public static string TownshipFile(DateTime date)
        {
            return string.Format(
                BasePath + "township/{0}", date.Year.ToString()
            );
        }

        public static string Category(int id)
        {
            return string.Format(
                BasePath + "categories/{0}/", id
            );
        }

        public static void Create(int id)
        {
            var paths = new List<string>();

            paths.Add(Course(id));
            paths.Add(CourseAttachments(id));
            paths.Add(Category(id));

            paths.ForEach(x =>
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/" + x));
            });
        }

        public static void Create(DateTime date)
        {
            var paths = new List<string>();

            paths.Add(CollegeFile(date));

            paths.ForEach(x =>
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/" + x));
            });
        }

        public static void Create(string path)
        {
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/" + path));
        }

    }
}
