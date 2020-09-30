using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Raylib_cs;

namespace behavior_tree
{
    class Wander : Behavior
    {
		float maxSpeed;
		float circleDistance;
		float circleRadius;
		float jitterAmount;

		Vector3 debugCirleCenter;
		Vector3 debugDisplacement;

		public Wander(float maxSpeed, float circleDistance, float circleRadius, float jitterAmount)
		{
			this.maxSpeed = maxSpeed;
			this.circleDistance = circleDistance;
			this.circleRadius = circleRadius;
			this.jitterAmount = jitterAmount;
		}
		public override BehaviorResult Execute(Agent agent, float dt)
        {
			Vector3 velocity = new Vector3(agent.velocity.x, agent.velocity.y, 0);
			Random rd = new Random();
			if (velocity.Magnitude() == 0)
			{
				velocity = (new Vector3(rd.Next(), rd.Next(), 0)).GetNormalize();
			}
			Vector3 circleCenter = velocity.GetNormalize() * circleDistance;
			Vector3 displacement = velocity.GetNormalize();
			displacement *= circleRadius;

			Vector3 offsetAmt = new Vector3(rd.Next() % jitterAmount * 2 - jitterAmount, rd.Next() % jitterAmount * 2 - jitterAmount, 0);
			displacement += offsetAmt;
			displacement = displacement.GetNormalize() * circleRadius;

			Vector3 force = circleCenter + displacement;
			force = force.GetNormalize() * maxSpeed;

			agent.velocity += force * dt;
			//agent.position += agent.velocity * dt;

			debugDisplacement = displacement;
			debugCirleCenter = circleCenter + agent.position;
			return BehaviorResult.Success;
		}
	}
}
