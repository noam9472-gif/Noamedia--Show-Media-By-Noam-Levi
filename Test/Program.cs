using Model;
using Noamedia__Show_Media_By_Noam_Levi;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using ViewModel;
internal class Program
{
    private static void Main(string[] args)
    {
        //        טבלת User
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
        ////User cInsert = new User();
        ////cInsert.UserName = "Noam Levi";
        ////cInsert.DateOfBirth = new DateTime(2008, 01, 20);
        ////cInsert.Mail = "noam9472@gmail.com";
        ////cInsert.Pass = "noamlevi2008";
        ////cInsert.Name = "NoamL20";
        ////cdb.Insert(cInsert);
        ////int y = cdb.SaveChanges();
        ////Console.WriteLine($"Inserted rows: {y}");

        //User cDelete = cList.Last();
        //cdb.Delete(cDelete);
        //int z = cdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");
        //foreach (User c in cList)
        //    Console.WriteLine(c);
        //Console.WriteLine();





        //        טבלת Genre
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









        //        טבלת Video
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






        //        טבלת VideoReview
        //        VideoReviewDB vrdb = new();
        //        VideoReviewList vrList = vrdb.SelectAll();
        //        foreach (VideoReview vr in vrList)
        //            Console.WriteLine(vr.ReviewDescription);

        //        Console.WriteLine();
        //        VideoReview vrUpdate = vrList[0];
        //        vrUpdate.ReviewDescription = "Review Updated Successfully";
        //        vrdb.Update(vrUpdate);
        //        int x = vrdb.SaveChanges();
        //        Console.WriteLine($"Updated rows: {x}");

        //        Console.WriteLine();
        //        VideoReview vrInsert = new VideoReview();
        //        vrInsert.WhoUpdatedTheReview = cList[0];
        //        vrInsert.WhichVideoDidTheUserReview = vList[0];
        //        vrInsert.ReviewDate = new DateTime(2023, 12, 18);
        //        vrInsert.ReviewDescription = "The video was terrible";
        //        vrdb.Insert(vrInsert);
        //        int y = vrdb.SaveChanges();
        //        Console.WriteLine($"Inserted rows: {y}");

        //VideoReview vrDelete = vrList.Last();
        //vrdb.Delete(vrDelete);
        //int z = vrdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");
        //foreach (VideoReview vr in vrList)
        //    Console.WriteLine(vr);
        //Console.WriteLine();


        //        טבלת AgeOfVideos
        //        AgeOfVideosDB aovdb = new();
        //        AgeOfVideoList aovList = aovdb.SelectAll();
        //        foreach (AgeOfVideos aov in aovList)
        //            Console.WriteLine(aov.Description);

        //        Console.WriteLine();
        //        AgeOfVideos aovUpdate = aovList[0];
        //        aovUpdate.Description = "Age Description Updates Successfully";
        //        aovdb.Update(aovUpdate);
        //        int x = aovdb.SaveChanges();
        //        Console.WriteLine($"Updated rows: {x}");

        //        Console.WriteLine();
        //        AgeOfVideos aovInsert = new AgeOfVideos();
        //        aovInsert.Description = "all ages";
        //        aovdb.Insert(aovInsert);
        //        int y = aovdb.SaveChanges();
        //        Console.WriteLine($"Inserted rows: {y}");

        //AgeOfVideos aovDelete = aovList.Last();
        //aovdb.Delete(aovDelete);
        //int z = aovdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");
        //foreach (AgeOfVideos aov in aovList)
        //    Console.WriteLine(aov);
        //Console.WriteLine();






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

        //        Console.WriteLine();
        //        UserPremium urInsert = new UserPremium();
        //        urInsert.IdentityCard = "78544625";
        //        urdb.Insert(urInsert);
        //        int y = urdb.SaveChanges();
        //        Console.WriteLine($"Inserted rows: {y}");

        //UserPremium urDelete = urList.Last();
        //urdb.Delete(urDelete);
        //int z = urdb.SaveChanges();
        //Console.WriteLine($"{z} rows were deleted");
        //foreach (UserPremium ur in urList)
        //    Console.WriteLine(ur);
        //Console.WriteLine();
    }
}
