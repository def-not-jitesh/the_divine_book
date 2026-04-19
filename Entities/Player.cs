using System; 
using System.Numerics;
using System.Collections.Generic; 
using Raylib_cs; 
using static Raylib_cs.Raylib; 

namespace Game.Entities 
{
	public class Player : Entity {
		Dictionary<State, int> stateSpriteIndex = new()
		{
			[State.Idle] = 9, 	
			[State.Run] = 6, 
			[State.Attack] = 12,
		};

		Dictionary<Direction, Vector2> spriteDirectionVector = new() 
		{
			[Direction.Right] = new Vector2(1, 0), 
			[Direction.Left] = new Vector2(-1, 0), 
			[Direction.Backward] = new Vector2(0, -1), 
			[Direction.Forward] = new Vector2(0, 1)
		}; 

		int currSpriteIndex = 0; 
		float scale = 1.5f;
	       	int maxFrames = 6;  
		int frameCounter = 0; 
		Direction cur_horizontal_direction; 

		public Player() {
			speed = 0.2f;
			size = new Vector2(80, 80);  
			health = 100;
		       	state = State.Idle; 
			position = new Vector2(100, 100); 	
		}

		public override void update(float deltaTime) {
			Console.WriteLine("state: " + state + "state_num: " + (int)state + "direction_num: " + (int)direction); 
			State oldstate = state; 

			if (IsKeyDown(KeyboardKey.W)) {
				float temp = position.Y - (speed * deltaTime); 
				position = new Vector2(position.X, temp);
				direction = Direction.Forward;  	
				if (state != State.Attack) {
					state = State.Run;
				}	
			} else if (IsKeyDown(KeyboardKey.A)) {
				position = new Vector2(position.X - (speed * deltaTime), position.Y); 
				direction = Direction.Left; 
				cur_horizontal_direction = Direction.Left; 
				if (state != State.Attack) {
					state = State.Run;
				} 
			} else if (IsKeyDown(KeyboardKey.D)) {
				position = new Vector2(position.X + (speed * deltaTime), position.Y);
			       	direction = Direction.Right;
				cur_horizontal_direction = Direction.Right; 
				if (state != State.Attack) {
					state = State.Run;
				} 	
			} else if (IsKeyDown(KeyboardKey.S)) {
				float temp = position.Y + (speed * deltaTime); 
				position = new Vector2(position.X, temp); 
				direction = Direction.Backward; 
				if (state != State.Attack) {
					state = State.Run;
				} 
			} else if (IsKeyDown(KeyboardKey.K)) {
				state = State.Attack;
			} else {
				if (state != State.Attack) {
					state = State.Idle;
				}
			}

			if (state != oldstate) {
				currSpriteIndex = 0; 
				frameCounter = 0;
			}

			frameCounter++; 
			if (frameCounter >= maxFrames) {
				currSpriteIndex++; 
				frameCounter = 0; 

				if (currSpriteIndex >= stateSpriteIndex[state]) {
					if (state == State.Attack) {
						state = State.Idle; 
					}
					currSpriteIndex = 0; 
				}
			}
		}

		public override void draw() {
			float spriteHeight = size.X;  
			float spriteWidth = size.Y;
		       	float rotation = 0.0f;	

			if (cur_horizontal_direction == Direction.Left) { 
				spriteWidth = -size.X; 
			}	

			DrawTexturePro(texture, new Rectangle(currSpriteIndex * size.X, (int)state * size.Y, spriteWidth, spriteHeight), 
					new Rectangle(position.X, position.Y, size.X * scale, size.Y * scale), new Vector2(0, 0), rotation, Color.White);
		}
	}
}
