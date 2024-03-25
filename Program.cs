using modul6_1302220013;
using System.ComponentModel;
using System.Diagnostics;

namespace modul6_1302220013
{
    class SayaTubeUser
    {
        private int Id;
        private List<SayaTubeVideo> uploadedVideos;
        private string Username;

        public SayaTubeUser(string username)
        {
            Debug.Assert(username != null && username.Length <= 100, "Username tidak boleh lebih dari 100 karakter");
            this.Username = username;
            this.Id = generateID();
            this.uploadedVideos = new List<SayaTubeVideo>();
        }
        public int generateID()
        {
            Random generate = new Random();
            return generate.Next(10000, 99999);
        }

        public int getTotalVideoPlayCount()
        {
            int sum = 0;

            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                sum += uploadedVideos.ElementAt(i).GetPlayCount();
            }
            return sum;
        }

        public void addVideo(SayaTubeVideo video)
        {
            Debug.Assert(video.GetPlayCount() <= int.MaxValue, "playcount nya tidak boleh lebih dari max value integer");
            uploadedVideos.Add(video);
        }

        public void PrintAllVideoPlaycount()
        {
            for (int i = 0;i < uploadedVideos.Count; i++)
            {
                Console.WriteLine(Username);
                Console.WriteLine("Judul: " + uploadedVideos.ElementAt(i).GetTitle());
                Console.WriteLine("PlayCount: " + uploadedVideos.ElementAt(i).GetPlayCount());
            }
        }
    }

    class SayaTubeVideo
    {
        private int Id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            Debug.Assert(title.Length <= 200 && title != null, "title tidak boleh lebih dari 200 karakter");
            this.title = title;
            this.playCount = 0;
            this.Id = generateID();
        }

        public int generateID()
        {
            Random generate = new Random();
            return generate.Next(10000, 99999);
        }

        public void increasePlayCount(int playCount)
        {
            Debug.Assert(playCount <= 25000000 && playCount >= 0 && this.playCount + playCount <= int.MaxValue, "Maksium playcount 25.000.000 dan ketika playcount ditambah tidak melebihi batas max value integer");

            try
            {
                checked 
                {
                    this.playCount += playCount;
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Kocak woi");
            }

            
        }

        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Play Count: {playCount}");
        }

        public int GetPlayCount()
        {
            return playCount;
        }
        public string GetTitle()
        {
            return title;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SayaTubeVideo v1 = new SayaTubeVideo("Review Film icikiwir oleh Rizky Kusuma Nugraha");
        SayaTubeVideo v2 = new SayaTubeVideo("Review Film wadagidaw oleh Rizky Kusuma Nugraha");
        SayaTubeVideo v3 = new SayaTubeVideo("Review Film Raya and The Last Dragon oleh Rizky Kusuma Nugraha");
        SayaTubeVideo v4 = new SayaTubeVideo("Review Film Godzilla vs Kong oleh Rizky Kusuma Nugraha");
        SayaTubeVideo v5 = new SayaTubeVideo("Review Film Cry Me A Sad River oleh Rizky Kusuma Nugraha");
        SayaTubeVideo v6 = new SayaTubeVideo("Review Film Black Swan oleh Rizky Kusuma Nugraha");
        SayaTubeVideo v7 = new SayaTubeVideo("Review Film Pawn oleh Rizky Kusuma Nugraha");
        SayaTubeVideo v8 = new SayaTubeVideo("Review Film Wonder oleh Rizky Kusuma Nugraha");
        SayaTubeVideo v9 = new SayaTubeVideo("Review Film Parasite oleh Rizky Kusuma Nugraha");
        SayaTubeVideo v10 = new SayaTubeVideo("Review Film  Gone Girl oleh Rizky Kusuma Nugraha");

       
        v1.increasePlayCount(1);
        v2.increasePlayCount(1);
        v3.increasePlayCount(1);
        v4.increasePlayCount(1);
        v5.increasePlayCount(1);
        v6.increasePlayCount(1);
        v7.increasePlayCount(1);
        v8.increasePlayCount(1);
        v9.increasePlayCount(1);
        v10.increasePlayCount(1);

        v1.PrintVideoDetails();
        v2.PrintVideoDetails();
        v3.PrintVideoDetails();
        v4.PrintVideoDetails();
        v5.PrintVideoDetails();
        v6.PrintVideoDetails();
        v7.PrintVideoDetails();
        v8.PrintVideoDetails();
        v9.PrintVideoDetails();
        v10.PrintVideoDetails();

        SayaTubeUser user1 = new SayaTubeUser("Rizky Kusuma Nugraha");

        user1.addVideo(v1);
        user1.addVideo(v2);
        user1.addVideo(v3);
        user1.addVideo(v4);
        user1.addVideo(v5);
        user1.addVideo(v6);
        user1.addVideo(v7);
        user1.addVideo(v8);
        user1.addVideo(v9);
        user1.addVideo(v10);

        user1.PrintAllVideoPlaycount();
        Console.WriteLine("Total playcount: " + user1.getTotalVideoPlayCount());
    }
}
