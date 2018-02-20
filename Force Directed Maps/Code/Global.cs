using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Force_Directed_Maps
{
    public static class Globals
    {
        public static int X_Con = 900;
        public static int Y_Con = 600;
        public static double HOOKES_CONSTANT = 0.000004;
        public static double ELECTROSTATIC_REPULSION = 20;
        public static double WALL_BOUNCE = -0.7;
        public static int ORIGINAL_SPRING_LENGTH = 100;
        public static double NEWTONS_GRAVITATIONAL = -0.1;
        public static double COEFFICIENT_OF_FRICTION =0.995;
        public static double MOUSE_POWER = 1000;
        public static double STOP_CONDITION = 0.2;
        public static List<IForceActor> Forces;

        public static int WIDTH { get { return X_Con; } }
        public static int HEIGHT { get { return Y_Con; } }
        public static double HOOKES { get { return HOOKES_CONSTANT; } }
        public static double REPULSION { get { return ELECTROSTATIC_REPULSION; } }
        public static double BOUNCE { get { return WALL_BOUNCE; } }
        public static int SPRING_LENGTH { get { return ORIGINAL_SPRING_LENGTH; } }
        public static double GRAVITY { get { return NEWTONS_GRAVITATIONAL; } }
        public static double RESISTANCE { get { return COEFFICIENT_OF_FRICTION; } }
        public static double MOUSE_STRENGTH { get { return MOUSE_POWER; } }
    }
}
