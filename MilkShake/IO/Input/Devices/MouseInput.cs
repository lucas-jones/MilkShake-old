﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MilkShakeFramework.Core.Scenes;

namespace MilkShakeFramework.IO.Input.Devices
{
    public class MouseInput
    {
        public static MouseState mouseState = Mouse.GetState();
        private static MouseState prvMouseState = mouseState;

        public static int ScrollChange()
        {
            return mouseState.ScrollWheelValue - prvMouseState.ScrollWheelValue;
        }

        #region Left Button
        public static bool isLeftClicked()
        {
            if (IsInBounds() && prvMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
                return true;

            return false;
        }

        public static bool isLeftDown()
        {
            if (IsInBounds() && prvMouseState.LeftButton == ButtonState.Pressed)
                return true;

            return false;
        }

        public static bool isLeftReleased()
        {
            if (IsInBounds() && prvMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                return true;

            return false;
        }
        #endregion

        #region Right Button
        public static bool isRightClicked()
        {
            if (IsInBounds() && prvMouseState.RightButton == ButtonState.Released && mouseState.RightButton == ButtonState.Pressed)
                return true;

            return false;
        }

        public static bool isRightDown()
        {
            if (IsInBounds() && prvMouseState.RightButton == ButtonState.Pressed)
                return true;

            return false;
        }

        public static bool isRightReleased()
        {
            if (IsInBounds() && prvMouseState.RightButton == ButtonState.Pressed && mouseState.RightButton == ButtonState.Released)
                return true;

            return false;
        }
        #endregion

        public static Vector2 Position
        {
            get { return new Vector2(mouseState.X, mouseState.Y); }
        }

        public static Vector2 WorldPosition
        {
            get { return SceneManager.CurrentScene.Camera.ScreenToWorld(Position); }
        }

        public static int X
        {
            get { return mouseState.X; }
        }

        public static int Y
        {
            get { return mouseState.Y; }
        }

        public static void UpdateStart()
        {
            mouseState = Mouse.GetState();
        }

        public static void UpdateEnd()
        {
            prvMouseState = mouseState;
        }

        public static Rectangle WorldBoundingBox
        {
            get { return new Rectangle((int)WorldPosition.X, (int)WorldPosition.Y, 1, 1); }
        }

        public static bool IsInBounds()
        {
            Rectangle screenRectangle = new Rectangle(0, 0, Globals.ScreenWidth, Globals.ScreenHeight);
            return screenRectangle.Intersects(new Rectangle((int)X, (int)Y, 1, 1));
        }
    }
}
