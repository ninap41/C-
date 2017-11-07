using System.Collections.Generic;

namespace pokemoninfo
{
    public class Pokemon
    {
        public string Name { get; set; }
        public List<string> Types { get; set; }
        public long Height { get; set; }
        public long Weight { get; set; }
    }
}