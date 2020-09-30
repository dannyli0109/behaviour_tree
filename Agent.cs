using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace behavior_tree
{
    class Agent
    {
        public Vector3 position;
        public Vector3 velocity;
        public Agent(Vector3 position)
        {
            this.position = position;
            Random rd = new Random();
            velocity = new Vector3(rd.Next() % 2 - 1, rd.Next() % 2 - 1, 0);
        }

        public void Update(float dt)
        {


            if (velocity.Magnitude() > 300)
            {
                velocity = velocity.GetNormalize() * 300;
            }

            position += velocity * dt;

            if (position.x > 1600 + 10)
            {
                position.x = 0;
            }

            if (position.x < 0 - 10)
            {
                position.x = 1600 + 10;
            }

            if (position.y > 960 + 10)
            {
                position.y = 0;
            }

            if (position.y < 0 - 10)
            {
                position.y = 960 + 10;
            }
        }

        public void Draw()
        {
            Raylib.DrawCircle((int)position.x, (int)position.y, 20, Color.RED);
        }
    }
}
