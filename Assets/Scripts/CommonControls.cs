using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class CommonControls
    {
        public int pos;
        private float lastDir;
        public Animator animator;
        public Vector3 currentDirection;
        public Camera cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        private bool facingRight = true;
        private bool rotateCamLeft;

        public readonly Vector2[] directions =
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(2, 0),
            new Vector2(1, 1),
            new Vector2(0, 1),
            new Vector2(4, 1),
            new Vector2(3, 0),
            new Vector2(4, 0),
        };

        public bool Flip(bool facingRight, Renderer r)
        {
            facingRight = !facingRight;
            var theScale = r.transform.localScale;
            theScale.x *= -1;
            r.transform.localScale = theScale;
            return facingRight;
        }

        public void RotateCamera(bool left, Transform t)
        {
            if (left)
            {
                if (pos == 7)
                    pos = -1;
                t.Rotate(Vector3.up, 45.0f, Space.World);
                ++pos;
            }
            else if (!left)
            {
                if (pos == 0)
                    pos = 8;
                t.Rotate(Vector3.up, -45.0f, Space.World);
                --pos;
            }

            var dir = directions[pos];
            animator.SetInteger("Direction", (int) dir.x);

            if (dir.y != lastDir)
            {
                facingRight = Flip(facingRight, t.GetComponentInChildren<Renderer>());
            }

            lastDir = dir.y;
        }
    }
}
