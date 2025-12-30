using Model;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ViewModel;
using ApiInterface;
using Server;
internal class Program
{
    private static async Task Main(string[] args)
    {

        #region User
        //UserDB cdb = new();
        //UserList cList = cdb.SelectAll();
        //foreach (User c in cList)
        //    Console.WriteLine(c.UserName);

        //        Console.WriteLine();
        //        User cUpdate = cList[0];
        //        cUpdate.Name = "Name Updated Successfully";
        //        cdb.Update(cUpdate);
        //        int x = cdb.SaveChanges();
        //        Console.WriteLine($"Updated rows: {x}");

        //Console.WriteLine();
        //User cInsert = new User();
        //cInsert.UserName = "Daniel Andreev";
        //cInsert.DateOfBirth = new DateTime(2008, 04, 08);
        //cInsert.Mail = "danielA@gmail.com";
        //cInsert.Pass = "DA2008";
        //cInsert.Name = "DAn12";
        //cdb.Insert(cInsert);
        //int y = cdb.SaveChanges();
        //Console.WriteLine($"Inserted rows: {y}");

        //User cDelete = cList.Last();
        //cdb.Delete(cDelete);
        //int z = cdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");
        //foreach (User c in cList)
        //    Console.WriteLine(c);
        //Console.WriteLine();

        #endregion

        #region Genre
        //GenreDB gdb = new();
        //GenreList gList = gdb.SelectAll();
        //foreach (Genre g in gList)
        //    Console.WriteLine(g.GenreDescription);

        //        Console.WriteLine();
        //        Genre gUpdate = gList[0];
        //        gUpdate.GenreDescription = "Genre Updated Successfully";
        //        gdb.Update(gUpdate);
        //        int x = gdb.SaveChanges();
        //        Console.WriteLine($"Updated rows: {x}");

        //Console.WriteLine();
        //Genre gInsert = new Genre();
        //gInsert.GenreDescription = "yyyy";
        //gdb.Insert(gInsert);
        //int y = gdb.SaveChanges();
        //Console.WriteLine($"Inserted rows: {y}");

        //Genre gDelete = gList.Last();
        //gdb.Delete(gDelete);
        //int z = gdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");
        //foreach (Genre g in gList)
        //    Console.WriteLine(g);
        //Console.WriteLine();


        #endregion

        #region Video
        //VideoDB vdb = new();
        //VideoList vList = vdb.SelectAll();
        //foreach (Video v in vList)
        //    Console.WriteLine(v.VideoName);

        //        Console.WriteLine();
        //        Video vUpdate = vList[0];
        //        vUpdate.VideoUploadedDate = DateTime.Now;
        //        vdb.Update(vUpdate);
        //        int x = vdb.SaveChanges();
        //        Console.WriteLine($"Updated rows: {x}");
        //        AgeOfVideosDB aovdb = new();
        //        AgeOfVideoList aovList = aovdb.SelectAll();
        //        foreach (AgeOfVideos aov in aovList)
        //            Console.WriteLine(aov.Description);

        //AgeOfVideosDB aovdb = new();
        //AgeOfVideoList aovList = aovdb.SelectAll();
        //foreach (AgeOfVideos aov in aovList)
        //    Console.WriteLine(aov.Description);

        //Console.WriteLine();
        //Video vInsert = new Video();
        //vInsert.VideoName = "It";
        //vInsert.LengthInMinutes = 30;
        //vInsert.VideoUploadedDate = new DateTime(2023, 12, 21);
        //vInsert.WhoUploadedTheVideo = cList[0];
        //vInsert.Genre = gList[0];
        //vInsert.AgeOfVideo = aovList[0];
        //vInsert.VideoAddress = "It";
        //vdb.Insert(vInsert);
        //int y = vdb.SaveChanges();
        //Console.WriteLine($"Inserted rows: {y}");

        //Video vDelete = vList.Last();
        //vdb.Delete(vDelete);
        //int z = vdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");
        //foreach (Video v in vList)
        //    Console.WriteLine(v);
        //Console.WriteLine();

        #endregion

        #region VideoReview
        //VideoReviewDB vrdb = new();
        //VideoReviewList vrList = vrdb.SelectAll();
        //foreach (VideoReview vr in vrList)
        //    Console.WriteLine(vr.ReviewDescription);

        //        Console.WriteLine();
        //        VideoReview vrUpdate = vrList[0];
        //        vrUpdate.ReviewDescription = "Review Updated Successfully";
        //        vrdb.Update(vrUpdate);
        //        int x = vrdb.SaveChanges();
        //        Console.WriteLine($"Updated rows: {x}");

        //Console.WriteLine();
        //VideoReview vrInsert = new VideoReview();
        //vrInsert.WhoUpdatedTheReview = cList[0];
        //vrInsert.WhichVideoDidTheUserReview = vList[0];
        //vrInsert.ReviewDate = new DateTime(2023, 11, 19);
        //vrInsert.ReviewDescription = "The video wasnt good enough";
        //vrdb.Insert(vrInsert);
        //int y = vrdb.SaveChanges();
        //Console.WriteLine($"Inserted rows: {y}");

        //VideoReview vrDelete = vrList.Last();
        //vrdb.Delete(vrDelete);
        //int z = vrdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");
        //foreach (VideoReview vr in vrList)
        //    Console.WriteLine(vr);
        //Console.WriteLine();
        #endregion

        #region AgeOfVideos
        //        טבלת AgeOfVideos
        //AgeOfVideosDB aovdb = new();
        //AgeOfVideoList aovList = aovdb.SelectAll();
        //foreach (AgeOfVideos aov in aovList)
        //    Console.WriteLine(aov.Description);

        //        Console.WriteLine();
        //        AgeOfVideos aovUpdate = aovList[0];
        //        aovUpdate.Description = "Age Description Updates Successfully";
        //        aovdb.Update(aovUpdate);
        //        int x = aovdb.SaveChanges();
        //        Console.WriteLine($"Updated rows: {x}");

        //Console.WriteLine();
        //AgeOfVideos aovInsert = new AgeOfVideos();
        //aovInsert.Description = "all ages";
        //aovdb.Insert(aovInsert);
        //int y = aovdb.SaveChanges();
        //Console.WriteLine($"Inserted rows: {y}");

        //AgeOfVideos aovDelete = aovList.Last();
        //aovdb.Delete(aovDelete);
        //int z = aovdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");
        //foreach (AgeOfVideos aov in aovList)
        //    Console.WriteLine(aov);
        //Console.WriteLine();
        #endregion

        #region UserPremium
        //        טבלת UserPremium
        //UserPremiumDB urdb = new();
        //UserPremiumList urList = urdb.SelectAll();
        //foreach (UserPremium ur in urList)
        //    Console.WriteLine(ur.IdentityCard);

        //        Console.WriteLine();
        //        UserPremium urUpdate = urList[0];
        //        urUpdate.IdentityCard = "Action";
        //        urdb.Update(urUpdate);
        //        int x = urdb.SaveChanges();
        //        Console.WriteLine($"Updated rows: {x}");

        //Console.WriteLine();
        //UserPremium urInsert = new UserPremium() ;
        //urInsert.UserName = "Itay Evron";
        //urInsert.DateOfBirth = new DateTime(2008, 07, 14);
        //urInsert.Mail = "ItayE@gmail.com";
        //urInsert.Pass = "IE2008";
        //urInsert.Name = "IEv13";
        //urInsert.IdentityCard = "12456798";
        //urdb.Insert(urInsert);
        //int y = urdb.SaveChanges();
        //Console.WriteLine($"Inserted rows: {y}");

        //UserPremium urDelete = urList.Last();
        //urdb.Delete(urDelete);
        //int z = urdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");
        //foreach (UserPremium ur in urList)
        //    Console.WriteLine(ur);
        //Console.WriteLine();
        #endregion

        #region User SelectAPI
        //InterfaceAPI api = new InterfaceAPI();
        //UserList users = await api.GetAllUsers();
        //foreach (var user in users)
        //{
        //    await Console.Out.WriteLineAsync(user.UserName);
        //}
        #endregion

        #region Genre InsertAPI
        InterfaceAPI api = new InterfaceAPI();
        UserList users = await api.GetAllUsers();
        foreach (var user in users)
        {
            await Console.Out.WriteLineAsync(user.UserName);
        }
    }
}
