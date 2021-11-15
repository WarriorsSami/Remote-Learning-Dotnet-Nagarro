using System;
using System.Collections.Generic;
using System.IO;
using GrandCircus.CircusModel.AnimalModels;

namespace GrandCircus.CircusModel
{
    public class AnimalFactory
    {
        private readonly StreamReader _reader;

        public AnimalFactory(string filePath)
        {
            _reader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read));
        }
        
        public List<IAnimal> GetAnimals()
        {
            var animals = new List<IAnimal>();
            var line = _reader.ReadLine();
            while (line != null)
            {
                var animal = GetAnimal(line);
                animals.Add(animal);
                line = _reader.ReadLine();
            }
            return animals;
        }
        
        private IAnimal GetAnimal(string line)
        {
            IAnimal animal;
            var animalData = line.Split(',');
            var animalSpecies = animalData[0];
            var animalName = animalData[1];

            switch (animalSpecies)
            {
                case "Elephant":
                    animal = new Elephant(animalName, animalSpecies);
                    break;
                case "Lion":
                    animal = new Lion(animalName, animalSpecies);
                    break;
                case "Snake":
                    animal = new Snake(animalName, animalSpecies);
                    break;
                case "Camel":
                    animal = new Camel(animalName, animalSpecies);
                    break;
                case "Cheetah":
                    animal = new Cheetah(animalName, animalSpecies);
                    break;
                case "GrizzlyBear":
                    animal = new GrizzlyBear(animalName, animalSpecies);
                    break;
                case "Kakadu":
                    animal = new Kakadu(animalName, animalSpecies);
                    break;
                case "Monkey":
                    animal = new Monkey(animalName, animalSpecies);
                    break;
                case "Seal":
                    animal = new Seal(animalName, animalSpecies);
                    break;
                case "Wolf":
                    animal = new Wolf(animalName, animalSpecies);
                    break;
                default:
                    throw new Exception("Invalid species");
            }
            return animal;
        }
    }
}