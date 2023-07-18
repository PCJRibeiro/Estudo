using System;
using Postagem.Entites;

namespace Postagem
{
    class Program
    {
        static void Main(string[] args)
        {
            Comment c1= new Comment("Have a nice trip");
            Comment c2 = new Comment("Wow that's awesome");

            Post p1 = new Post(
                DateTime.Parse("21/06/2023 13:05:44"),"Traveling to New Zeland","to indo pra um lugar longe pra carai",12);
            p1.AddComment(c1);
            p1.AddComment(c2);

            Comment c3 = new Comment("Vai toma no cu piranha");
            Comment c4 = new Comment("Devendo 5k pro agiota e ta viajando");
            Post p2 = new Post(
                DateTime.Parse("12/07/2023 14:23:20"), "thank you", "Tyler banger",90);
            p2.AddComment(c3);
            p2.AddComment(c4);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }
}
