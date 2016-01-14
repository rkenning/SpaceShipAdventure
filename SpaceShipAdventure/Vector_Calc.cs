﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpaceshipCommander
{
    public static class  Vector_Calc
    {
        public static int new_x (int speed_, int angle_, int cur_x_  )
            {
        
            double angle = angle_ * (Math.PI / 180);  // angle, in radians, that the player is facing
                                              // note:  angle 0 is due east, not due north.  Rotates counter-clockwise,
                                              //  so angle 90 degrees is due north.
            double new_x = cur_x_ + (speed_ * Math.Cos(angle_));
            return Convert.ToInt16(new_x);
        }

        public static int new_y(int speed_, int angle_, int cur_y_)
        {
  
            double angle = angle_ * (Math.PI / 180);  // angle, in radians, that the player is facing
                                              // note:  angle 0 is due east, not due north.  Rotates counter-clockwise,
                                              //  so angle 90 degrees is due north.
            double new_y = cur_y_ + (speed_ * Math.Sin(angle));
            
            return Convert.ToInt16(new_y);
        }



    }
}
