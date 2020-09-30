using System;
using Raylib_cs;

namespace behavior_tree
{
    class Program
    {
        public static void Main()
        {
            Raylib.InitWindow(1600, 960, "Hello World");
            Agent agent = new Agent(new Vector3(300, 300, 1));
            Agent target = new Agent(new Vector3(Raylib.GetMouseX(), Raylib.GetMouseY(), 1));

            Selector agentBehavior = new Selector();
            
            Sequence attackSequence = new Sequence();
            TargetWithin targetWithin50 = new TargetWithin(target, 50);
            Attack attack = new Attack();
            Wait wait = new Wait(0.2f, 0.2f);

            attackSequence.children.Add(targetWithin50);
            attackSequence.children.Add(wait);
            attackSequence.children.Add(attack);

            Selector patrolBehavior = new Selector();
            Sequence seekSequence = new Sequence();
            TargetWithin targetWithin200 = new TargetWithin(target, 200);
            Seek seek = new Seek(target, 300);
            
            Wander wander = new Wander(300, 80, 50, 200);
            WaitDecorator waitDecorator = new WaitDecorator(wander, 0.2f, 0.2f);

            seekSequence.children.Add(targetWithin200);
            seekSequence.children.Add(seek);

            patrolBehavior.children.Add(seekSequence);
            patrolBehavior.children.Add(waitDecorator);

            agentBehavior.children.Add(attackSequence);
            agentBehavior.children.Add(patrolBehavior);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                //Raylib.DrawText("Hello, world!", 12, 12, 20, Color.BLACK);

                float dt = Raylib.GetFrameTime();
                target.position.x = Raylib.GetMouseX();
                target.position.y = Raylib.GetMouseY();
                agentBehavior.Execute(agent, dt);
                agent.Update(dt);
                agent.Draw();


                if ((agent.position - target.position).Magnitude() <= 50)
                {
                    Raylib.DrawCircleLines((int)agent.position.x, (int)agent.position.y, 50, Color.RED);
                    Raylib.DrawCircleLines((int)agent.position.x, (int)agent.position.y, 200, Color.GREEN);
                }
                else
                {
                    Raylib.DrawCircleLines((int)agent.position.x, (int)agent.position.y, 50, Color.GREEN);
                    if ((agent.position - target.position).Magnitude() <= 200)
                    {
                        Raylib.DrawCircleLines((int)agent.position.x, (int)agent.position.y, 200, Color.RED);
                    }
                    else
                    {
                        Raylib.DrawCircleLines((int)agent.position.x, (int)agent.position.y, 200, Color.GREEN);
                    }

                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}
