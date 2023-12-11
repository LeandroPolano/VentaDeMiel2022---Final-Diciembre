using System;
using System.IO;
using System.Web;

namespace VentaDeMiel2022.Web.Helpers
{
    public class HelperFile
    {
        public static bool UploadPhoto(HttpPostedFileBase photoFile, string folder, string photoName)
        {
            if (photoFile == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(photoName))
            {
                return false;
            }

            try
            {
                var path = Path.Combine(HttpContext.Current.Server.MapPath(folder), photoName);
                photoFile.SaveAs(path);
                return true;
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades, por ejemplo, registrarla
                return false;
            }
        }

        public static bool DeletePhoto(string photoName)
        {
            try
            {
                var photoFile = new FileInfo(HttpContext.Current.Server.MapPath(photoName));
                if (!photoFile.Exists)
                {
                    return false;
                }

                photoFile.Delete();
                return true;
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades, por ejemplo, registrarla
                return false;
            }
        }
    }
}
