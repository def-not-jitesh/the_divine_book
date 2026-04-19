using System.Numerics; 
using Raylib_cs; 
using static Raylib_cs.Raylib; 

namespace Game.Entities
{

	public enum Direction {
		Right, 
		Left, 
		Forward, 
		Backward
	}

	public enum State {
		Idle, 
		Run, 
		Attack, 
		Die, 
		Damage 
	}

	public abstract class Entity {
		protected int health; 
		protected float speed; 
		protected Texture2D texture; 
		protected Vector2 position; 
		protected Direction direction; 
		protected State state; 
		protected Vector2 size; 

		public void loadTexture(string path) {
			texture = LoadTexture(path); 
		}

		public abstract void update(float deltaTime); 
		public abstract void draw();

	}
}

