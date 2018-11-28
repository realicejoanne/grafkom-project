﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;

namespace RubikCube.Draws {
    class Light : IDraw {
        private int AngleX = 0;
        private int AngleY = 0;
        private int AngleZ = 0;

        public bool IsDiffuseLightEnabled { get; set; }
        public bool IsSpecularLightEnabled { get; set; }
        public bool IsAmbientLightEnabled { get; set; }

        public float[] AmbientLight { get; set; }
        public float[] DiffuseLight { get; set; }
        public float[] SpecularLight { get; set; }
        public float[] LightPosition { get; set; }
        public float[] Specularity { get; set; }
        public float[] Blackout { get; set; }

        private int GlLight;

        public Light(int GlLight, float[] LightPosition){
            this.GlLight = GlLight;

            this.IsAmbientLightEnabled = true;
            this.IsDiffuseLightEnabled = true;
            this.IsSpecularLightEnabled = false;

            this.LightPosition = LightPosition;
            this.AmbientLight = new float[3] { .2f, .2f, .2f };
            this.DiffuseLight = new float[3] { .8f, .8f, .8f };
            this.SpecularLight = new float[3] { .7f, .7f, .7f };
            this.Specularity = new float[3] { .2f, .2f, .2f };
            this.Blackout = new float[3] { 0f, 0f, 0f };

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            Gl.glShadeModel(Gl.GL_SMOOTH);

            Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, Specularity);
            Gl.glMaterialfv(Gl.GL_BACK, Gl.GL_SPECULAR, Specularity);

            Gl.glMateriali(Gl.GL_FRONT, Gl.GL_SHININESS, 100);
            Gl.glMateriali(Gl.GL_BACK, Gl.GL_SHININESS, 100);
        }

        public void Draw(){
            //Gl.glPushMatrix();

            Gl.glRotatef(this.AngleX, 1, 0, 0);
            Gl.glRotatef(this.AngleY, 0, 1, 0);
            Gl.glRotatef(this.AngleZ, 0, 0, 1);

            Gl.glLightfv(this.GlLight, Gl.GL_POSITION, LightPosition);

            //Gl.glPopMatrix();

            Gl.glEnable(this.GlLight);
        }

        public void Rotate(int AngleAxisX, int AngleAxisY, int AngleAxisZ){
            this.AngleX += AngleAxisX;
            this.AngleY += AngleAxisY;
            this.AngleZ += AngleAxisZ;
        }

    }
}
