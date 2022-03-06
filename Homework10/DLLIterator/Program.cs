using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;

try
{
    var currentDirectory = Directory.GetCurrentDirectory();
    var pathToDll = currentDirectory + "\\Npgsql.dll";
    var pathToLogFile = currentDirectory + "\\log.txt";

    using StreamWriter file = new(pathToLogFile);
    var assembly = Assembly.LoadFile(pathToDll);
    var types = assembly.GetTypes();

    file.WriteLine($"Assembly {assembly.FullName} contains {types.Length} types");
    foreach (var type in types)
    {
        file.WriteLine($"Type {type.FullName}");
        var methods = type.GetMethods();
        var properties = type.GetProperties();
        var fields = type.GetFields();
        var events = type.GetEvents();
        var constructors = type.GetConstructors();
        var interfaces = type.GetInterfaces();
        var nestedTypes = type.GetNestedTypes();
        var attributes = type.GetCustomAttributes();
        var methodsWithAttributes = methods.Where(m => m.GetCustomAttributes().Any());
        var propertiesWithAttributes = properties.Where(p => p.GetCustomAttributes().Any());
        var fieldsWithAttributes = fields.Where(f => f.GetCustomAttributes().Any());
        var eventsWithAttributes = events.Where(e => e.GetCustomAttributes().Any());
        var constructorsWithAttributes = constructors.Where(c => c.GetCustomAttributes().Any());
        var interfacesWithAttributes = interfaces.Where(i => i.GetCustomAttributes().Any());
        var nestedTypesWithAttributes = nestedTypes.Where(n => n.GetCustomAttributes().Any());
        var genericArguments = type.GetGenericArguments();
        var subclasses = types.Where(t => t.IsSubclassOf(type));
        var interfacesImplemented = interfaces.Where(i => type.GetInterfaces().Contains(i));

        foreach (var method in methods)
        {
            file.WriteLine($"\tMethod {method.Name}");
            var parameters = method.GetParameters();
            foreach (var parameter in parameters)
            {
                file.WriteLine($"\t\tParameter {parameter.Name}");
            }
        }

        foreach (var property in properties)
        {
            file.WriteLine($"\tProperty {property.Name}");
        }

        foreach (var field in fields)
        {
            file.WriteLine($"\tField {field.Name}");
        }

        foreach (var @event in events)
        {
            file.WriteLine($"\tEvent {@event.Name}");
        }

        foreach (var constructor in constructors)
        {
            file.WriteLine($"\tConstructor {constructor.Name}");
        }

        foreach (var @interface in interfaces)
        {
            file.WriteLine($"\tInterface {@interface.Name}");
        }

        foreach (var nestedType in nestedTypes)
        {
            file.WriteLine($"\tNestedType {nestedType.Name}");
        }

        foreach (var attribute in attributes)
        {
            file.WriteLine($"\tAttribute {attribute.GetType().Name}");
        }

        foreach (var methodWithAttribute in methodsWithAttributes)
        {
            file.WriteLine($"\tMethodWithAttribute {methodWithAttribute.Name}");
        }

        foreach (var propertyWithAttribute in propertiesWithAttributes)
        {
            file.WriteLine($"\tPropertyWithAttribute {propertyWithAttribute.Name}");
        }

        foreach (var fieldWithAttribute in fieldsWithAttributes)
        {
            file.WriteLine($"\tFieldWithAttribute {fieldWithAttribute.Name}");
        }

        foreach (var eventWithAttribute in eventsWithAttributes)
        {
            file.WriteLine($"\tEventWithAttribute {eventWithAttribute.Name}");
        }

        foreach (var constructorWithAttribute in constructorsWithAttributes)
        {
            file.WriteLine($"\tConstructorWithAttribute {constructorWithAttribute.Name}");
        }

        foreach (var interfaceWithAttribute in interfacesWithAttributes)
        {
            file.WriteLine($"\tInterfaceWithAttribute {interfaceWithAttribute.Name}");
        }

        foreach (var nestedTypeWithAttribute in nestedTypesWithAttributes)
        {
            file.WriteLine($"\tNestedTypeWithAttribute {nestedTypeWithAttribute.Name}");
        }

        foreach (var genericArgument in genericArguments)
        {
            file.WriteLine($"\tGenericArgument {genericArgument.Name}");
        }

        foreach (var subclass in subclasses)
        {
            file.WriteLine($"\tSubclass {subclass.Name}");
        }

        foreach (var interfaceImplemented in interfacesImplemented)
        {
            file.WriteLine($"\tInterfaceImplemented {interfaceImplemented.Name}");
        }
    }

    file.WriteLine("\nAll public sealed non-abstract classes:");
    types
        .Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && t.IsSealed)
        .ToList()
        .ForEach(file.WriteLine);

    file.WriteLine("\nAll public generic interfaces:");
    types
        .Where(t => t.IsInterface && t.IsPublic && t.IsGenericType)
        .ToList()
        .ForEach(file.WriteLine);

    file.WriteLine("\nAll public generic classes:");
    types.Where(t => t.IsClass && t.IsPublic && t.IsGenericType).ToList().ForEach(file.WriteLine);

    file.WriteLine("\nAll public generic classes with a single generic argument:");
    types
        .Where(
            t => t.IsClass && t.IsPublic && t.IsGenericType && t.GetGenericArguments().Length == 1
        )
        .ToList()
        .ForEach(file.WriteLine);

    file.WriteLine("\nAll delegates:");
    types.Where(t => t.IsSubclassOf(typeof(Delegate))).ToList().ForEach(file.WriteLine);

    file.WriteLine("\nAll collections:");
    types.Where(t => t.IsSubclassOf(typeof(Collection<>))).ToList().ForEach(file.WriteLine);

    file.WriteLine("\nAll private anonymous types:");
    types
        .Where(
            t =>
                t.IsClass && t.IsNotPublic && t.IsDefined(typeof(CompilerGeneratedAttribute), false)
        )
        .ToList()
        .ForEach(file.WriteLine);

    file.WriteLine("\nAll internal enums:");
    types.Where(t => t.IsEnum && t.IsNotPublic).ToList().ForEach(file.WriteLine);

    file.WriteLine("\nAll extension methods:");
    types
        .Where(t => t.IsClass && t.IsSealed && t.IsDefined(typeof(ExtensionAttribute), false))
        .ToList()
        .ForEach(file.WriteLine);

    file.WriteLine("\nAll abstract classes:");
    types.Where(t => t.IsClass && t.IsAbstract).ToList().ForEach(file.WriteLine);

    file.WriteLine("\nAll structs:");
    types.Where(t => t.IsValueType && !t.IsEnum).ToList().ForEach(file.WriteLine);

    file.WriteLine("\nAll derived classes which inherit from a sealed class:");
    types
        .Where(t => t.IsClass && t.IsSealed && t.BaseType is { IsSealed: true })
        .ToList()
        .ForEach(file.WriteLine);

    file.WriteLine("\nAll unimplemented methods from interfaces:");
    types
        .Where(t => t.IsInterface)
        .ToList()
        .ForEach(
            t =>
            {
                var methods = t.GetMethods();
                var implementedMethods = t.GetInterfaces().SelectMany(i => i.GetMethods());
                var unimplementedMethods = methods.Except(implementedMethods);
                unimplementedMethods.ToList().ForEach(file.WriteLine);
            }
        );

    file.WriteLine("\nAll methods with a custom attribute:");
    types
        .Where(t => t.IsClass && t.IsSealed && t.IsDefined(typeof(CustomAttribute), false))
        .ToList()
        .ForEach(file.WriteLine);
    
    file.WriteLine("\nAll enum values grouped by enum:");
    types.Where(t => t.IsEnum).ToList().ForEach(
        t =>
        {
            var values = Enum.GetValues(t);
            var groupedValues = values.Cast<object>().GroupBy(v => v.GetType());
            groupedValues.ToList().ForEach(
                g =>
                {
                    file.WriteLine($"\t{g.Key}");
                    g.ToList().ForEach(file.WriteLine);
                }
            );
            file.WriteLine();
        }
    );
    
    file.WriteLine("\nAll covariant generic types:");
    types
        .Where(t => t.IsGenericType && t.IsClass && t.IsSealed && t.IsGenericTypeDefinition)
        .ToList()
        .ForEach(
            t =>
            {
                var typeArguments = t.GetGenericArguments();
                var covariantTypes = typeArguments.Where(
                    ta =>
                    {
                        var taType = ta.BaseType;
                        return taType is {IsGenericType: true} && taType.GetGenericTypeDefinition() == t;
                    }
                );
                covariantTypes.ToList().ForEach(file.WriteLine);
            }
        );
    
    file.WriteLine("\nAll readonly fields from public classes:");
    types
        .Where(t => t.IsClass && t.IsPublic && t.IsSealed)
        .ToList()
        .ForEach(
            t =>
            {
                var fields = t.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                var readonlyFields = fields.Where(f => f.IsInitOnly);
                readonlyFields.ToList().ForEach(file.WriteLine);
            }
        );
}
catch (BadImageFormatException e)
{
    Console.WriteLine(e.Message);
}
catch (FileNotFoundException e)
{
    Console.WriteLine(e.Message);
}
