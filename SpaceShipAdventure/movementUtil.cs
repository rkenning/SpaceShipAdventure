using System;

namespace SpaceshipCommander
{
    public static class  MovementUtil
    {
        public static int new_x (int speed_, int angle_, int cur_x_  )
            {

            //Apply - 90 offset as I want angle 0 to be pointing north
            double angleR = (angle_-90 ) * (Math.PI / 180);  
                                              // angle, in radians, that the player is facing
                                              // note:  angle 0 is due east, not due north.  Rotates counter-clockwise,
                                              //  so angle 90 degrees is due north.
            double new_x = cur_x_ + (speed_ * Math.Cos(angleR));
            return Convert.ToInt16(new_x);
        }

        public static int new_y(int speed_, int angle_, int cur_y_)
        {

            //Apply - 90 offset as I want angle 0 to be pointing north
            double angleR = (angle_-90) * (Math.PI / 180);  
                                              // angle, in radians, that the player is facing
                                              // note:  angle 0 is due east, not due north.  Rotates counter-clockwise,
                                              //  so angle 90 degrees is due north.
            double new_y = cur_y_ + (speed_ * Math.Sin(angleR));
            
            return Convert.ToInt16(new_y);
        }
       
        
        }



}
