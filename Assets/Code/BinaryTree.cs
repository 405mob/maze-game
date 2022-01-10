using System.Collections;
using System;
using UnityEngine;

public class BinaryTree : MonoBehaviour
{
	public GameObject wall;
	private int[,] maze = new int[27, 27];

	void Start()
  {
		template();
		carve();
		BuildMaze();
	}


	//makes the template to carve the maze out of of 1s surrounded by 0s
	//0s represent walls 1 represents path
	void template()
	{

		for (int row = 0; row < 27; row++)
		{
			for (int col = 0; col < 27; col++)
			{
				if ((row % 2 != 0 && col % 2 != 0) && col != 26 && col != 0)
				{
					maze[row, col] = 1;
				}
				else
				{
					maze[row, col] = 0;
				}
			}
		}
	}

	//carves out a path in the matrix using the binary tree algorithm
	void carve()
	{
		System.Random rand = new System.Random();

		for (int row = 1; row < 27; row += 2)
		{
			for (int col = 1; col < 27; col += 2)
			{
				// 0 carve right else carve down
				if (rand.Next(2) == 0)
				{
					if (col + 1 != 26)
					{
						maze[row, col + 1] = 1;
					}
					else
					{
						maze[row + 1, col] = 1;
					}
				}
				else
				{
					if (row + 1 != 26)
					{
						maze[row + 1, col] = 1;
					}
					else
					{
						maze[row, col + 1] = 1;
					}
				}
			}
		}
		maze[0, 1] = 1;
	}

	//builds maze (if cell has value 0 builds wall)
	void BuildMaze()
	{
		for (int row = 0; row < 27; row++)
    {
			for (int col = 0; col < 27; col++)
      {
				if(maze[row, col] == 0)
        {
					var slab = Instantiate<GameObject>(wall);
					slab.transform.position = new Vector3(-13+row, 0, -13+col);
				}
      }
		}
	}
}
