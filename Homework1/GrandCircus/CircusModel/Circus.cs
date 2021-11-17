using System.Collections.Generic;
using GrandCircus.Presentation;

namespace GrandCircus.CircusModel
{
    internal class Circus
    {
        private readonly List<IAnimal> _animals;
        private readonly string _name;
        
        private readonly AnimalFactory _animalFactory;
        private readonly Arena _arena;

        public Circus(Arena arena, string name, string animalFileIn)
        {
            _arena = arena;
            _name = name;
            
            _animalFactory = new AnimalFactory(animalFileIn);
            _animals = _animalFactory.GetAnimals();
        }

        public void Perform()
        {
            _arena.PresentCircus(_name);
            
            foreach (var animal in _animals)
            {
                Perform(animal);
            }
        }
        
        private void Perform(IAnimal animal)
        {
            _arena.AnnounceAnimal(animal.Name, animal.SpeciesName);
            _arena.DisplayAnimalPerformance(animal.MakeSound());
        }
    }
}