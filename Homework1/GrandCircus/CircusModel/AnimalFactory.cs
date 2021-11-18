using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using GrandCircus.CircusModel.AnimalModels;

namespace GrandCircus.CircusModel
{
    public class AnimalReader
    {
        private readonly StreamReader _reader;

        public AnimalReader(string filePath)
        {
            _reader = new StreamReader(filePath);
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
            var animalData = line.Split(',');
            var animalSpecie = animalData[0];
            var animalName = animalData[1];

            // TODO: Refactor this to use reflection properly
            // var animalDemo = AnimalFactory
            //     .CreateAnimal("GrandCircus.CircusModel.AnimalModels." + animalSpecie);

            IAnimal animal = animalSpecie switch
            {
                "Elephant" => new Elephant(animalName, animalSpecie),
                "Lion" => new Lion(animalName, animalSpecie),
                "Snake" => new Snake(animalName, animalSpecie),
                "Camel" => new Camel(animalName, animalSpecie),
                "Cheetah" => new Cheetah(animalName, animalSpecie),
                "GrizzlyBear" => new GrizzlyBear(animalName, animalSpecie),
                "Kakadu" => new Kakadu(animalName, animalSpecie),
                "Monkey" => new Monkey(animalName, animalSpecie),
                "Seal" => new Seal(animalName, animalSpecie),
                "Wolf" => new Wolf(animalName, animalSpecie),
                _ => throw new Exception("Invalid species")
            };
            return animal;
        }
    }
    
    public static class AnimalFactory
    {
        public static IAnimal CreateAnimal<T>() where T : IAnimal
        {
            return Activator.CreateInstance<T>();
        }

        public static IAnimal CreateAnimal(string animalSpecie)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(animalSpecie)?.FullName;
            Console.WriteLine(type);
            return Activator
                .CreateInstanceFrom(assembly.Location, type ?? string.Empty)
                ?.Unwrap() as IAnimal;
        }
    }
}