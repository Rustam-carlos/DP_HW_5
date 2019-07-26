using System;

namespace DP_HW_5
{
    class Client
    {
        public void SeeFilms(Shop library)
        {
            IFilmIterator iterator = library.CreateNumerator();
            while (iterator.HasNext())
            {
                Film film = iterator.Next();
                Console.WriteLine(film.Name);
            }
        }
    }

    interface IFilmIterator
    {
        bool HasNext();
        Film Next();
    }
    interface IFilmNumerable
    {
        IFilmIterator CreateNumerator();
        int Count { get; }
        Film this[int index] { get; }
    }
    class Film
    {
        public string Name { get; set; }
    }

    class Shop : IFilmNumerable
    {
        private Film[] films;
        public Shop()
        {
            films = new Film[]
            {
            new Film{Name="Война миров"},
            new Film {Name="Криминальное чтиво"},
            new Film {Name="Убить Билла"}
            };
        }
        public int Count
        {
            get { return films.Length; }
        }

        public Film this[int index]
        {
            get { return films[index]; }
        }
        public IFilmIterator CreateNumerator()
        {
            return new ShopNumerator(this);
        }
    }
    class ShopNumerator : IFilmIterator
    {
        IFilmNumerable aggregate;
        int index = 0;
        public ShopNumerator(IFilmNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }

        public Film Next()
        {
            return aggregate[index++];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            Client reader = new Client();
            reader.SeeFilms(shop);

            Console.Read();
        }
    }
}
