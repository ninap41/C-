using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist filterfind = Artists.Where(artist => artist.Hometown == "Mount Vernon").Single();
            Console.WriteLine($"{filterfind.ArtistName} from Mt Vernon is {filterfind.Age}");

            //Who is the youngest artist in our collection of artists?
            Artist findyoung = Artists.OrderBy(artist => artist.Age).First();
            Console.WriteLine($"{findyoung.ArtistName} is the youngest artist, he is {findyoung.Age}.");


   
            //Display all artists with 'William' somewhere in their real name
            List<Artist> Williams = Artists.Where(artist => artist.RealName.Contains("William")).ToList();
            foreach(var artist in Williams){            
            Console.WriteLine($"{artist.ArtistName}'s real name is {artist.RealName}");
            }


            //Display the 3 oldest artist from Atlanta

            List<Artist> oldpeople = Artists.Where(artist=> artist.Hometown == "Atlanta").Take(3).ToList();
            foreach(var artist in oldpeople){
                Console.WriteLine($"{artist.ArtistName} is from {artist.Hometown} and is {artist.Age}");
            }
            

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<string> NonNewYorkGroups = Artists
                                .Join(Groups, artist => artist.GroupId, group => group.Id, (artist, group) => { artist.Group = group; return artist;})
                                .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                                .Select(artist => artist.Group.GroupName)
                                .Distinct()
                                .ToList();
            Console.WriteLine("All groups with members not from New York City:");
            foreach(var group in NonNewYorkGroups){
                Console.WriteLine(group);
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'

            Group WuTang = Groups.Where(group => group.GroupName == "Wu-Tang Clan")
                                    .GroupJoin(Artists, 
                                        group => group.Id,
                                        artist => artist.GroupId,
                                        (group, artists) => { group.Members = artists.ToList(); return group;})
                                    .Single();
            Console.WriteLine("List of Artist in the Wu-Tang Clan:");
            foreach(var artist in WuTang.Members)
            {
            Console.WriteLine(artist.ArtistName);
            }
        }
    }
}


