using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreSerializationClassLibrary.Service
{
    internal class DataSerializer
    {
       
            public static void BinarySerializer(string filePath, List<Movie> movies)
            {
                try
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Create))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(file, movies);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during binary serialization: {ex.Message}");
                }
            }

            public static List<Movie> BinaryDeserializer(string filePath)
            {
                List<Movie> movies = new List<Movie>();

                try
                {
                    using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        if (file.Length > 0)
                        {
                            movies = (List<Movie>)bf.Deserialize(file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error during binary deserialization: {ex.Message}");
                }

                return movies;
            }
        }
    }



