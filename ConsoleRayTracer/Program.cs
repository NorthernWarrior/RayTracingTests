using RayTracingCore_CS;
using RayTracingCore_CS.Math;
using RayTracingCore_CS.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRayTracer
{
    class Program
    {
        const float ScreenWidth = 75;
        const float ScreenHeight = 75;

        static void Main(string[] args)
        {
            Console.SetWindowSize((int)ScreenWidth, (int)ScreenHeight + 1);
            Console.SetBufferSize((int)ScreenWidth, (int)ScreenHeight + 1);
            Console.CursorVisible = false;

            var scene = new Scene();

            Sphere player = new Sphere(new Vector3(ScreenWidth / 2, ScreenHeight / 2, 0), 5, ConsoleColor.Green);

            scene.AddObject(player);
            scene.AddObject(new Circle(new Vector3(20, 20, 0), Vector3.Forward, 10, ConsoleColor.Red));
            scene.AddObject(new Circle(new Vector3(20, 60, -4), Vector3.Forward, 10, ConsoleColor.Red));
            scene.AddObject(new Quad(new Vector3(ScreenWidth / 2, ScreenHeight / 2, 0), new Vector3(0.65f, 0.2f, 0.15f), 20, ConsoleColor.White));


            var ray = new Ray();
            HitInfo hitInfo;
            Stopwatch timer = new Stopwatch();
            float deltaTime = 0;
            while (true)
            {
                timer.Stop();
                deltaTime = timer.ElapsedMilliseconds / 1000f;
                timer.Reset();
                timer.Start();

                #region Interaction-Logic
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = default(ConsoleKeyInfo);
                    while (Console.KeyAvailable)
                    {
                        pressedKey = Console.ReadKey(true);
                    }
                    var moveSpeed = 5 * deltaTime;
                    if (pressedKey.Key == ConsoleKey.W)
                        player.Move(0, moveSpeed, 0);
                    if (pressedKey.Key == ConsoleKey.A)
                        player.Move(-moveSpeed, 0, 0);
                    if (pressedKey.Key == ConsoleKey.S)
                        player.Move(0, -moveSpeed, 0);
                    if (pressedKey.Key == ConsoleKey.D)
                        player.Move(moveSpeed, 0, 0);

                    if (pressedKey.Key == ConsoleKey.UpArrow)
                        player.Move(0, 0, 1);
                    if (pressedKey.Key == ConsoleKey.DownArrow)
                        player.Move(0, 0, -1);
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                        player.Radius -= 1;
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                        player.Radius += 1;
                }

                #endregion

                #region Ray-Tracing-Logic

                Console.SetCursorPosition(0, 0);
                for (int y = 0; y < ScreenHeight; ++y)
                {
                    for (int x = 0; x < ScreenWidth; ++x)
                    {
                        ray.Origin = new Vector3(x, ScreenHeight - y, -10);
                        ray.Direction = Vector3.Forward;

                        if (scene.GetRayIntersection(ray, out hitInfo))
                        {
                            Console.ForegroundColor = hitInfo.ConsoleColor;
                            Console.Write('#');
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                }

                #endregion

                //System.Threading.Thread.Sleep(100);
                Console.ForegroundColor = ConsoleColor.White;
                string line = "DeltaTime: " + deltaTime + " -- Player| Z: " + player.Center.Z + " Radius: " + player.Radius;
                Console.Write(line + new string(' ', ((int)ScreenWidth - line.Length - 1)));
            }
        }
    }
}
