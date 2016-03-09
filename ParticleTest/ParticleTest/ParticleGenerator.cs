using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParticleTest
{
    class ParticleGenerator
    {
        /// <summary>
        /// PARTICLE SETTINGS
        /// </summary>
        private Texture2D _texture;
        Vector2 _ruch;
        private Vector2 _pos;
        private float _rotation;
        private float _scale;
        private SpriteEffects _efekt;
        float _alpha;
        private int _ttl;
        private float _tl;
        public event EventHandler Event_Dodaj;
        public event EventHandler Event_Usun;
        /////////////////////////////////////
        int _spawn_distance;
        float _czestotliwosc;
        Random _rand;
        /////////////////////////////////////
        public ParticleGenerator(Texture2D txt, Vector2 pos, Vector2 ruch, int _TimeToLive,float czestotliwosc,int spawndistance )
        {
            _rand = new Random(DateTime.Now.Second);
            _texture = txt;
            _pos = pos;
            _ruch = ruch;
            _ttl = _TimeToLive;
            _czestotliwosc = czestotliwosc;
            _tl = 0;
            _spawn_distance = spawndistance;
        }

        public void Update(GameTime gameTime)
        {
            _tl += gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            if (_tl > _czestotliwosc)
            {
                _tl -= _czestotliwosc;
                Vector2 _spawn = new Vector2(_pos.X, _pos.Y);
                _spawn.X += _rand.Next(_spawn_distance);
                _spawn.Y += _rand.Next(_spawn_distance);
                Particle obj = new Particle(_texture, _spawn, _ruch, _ttl,true);
                obj.Event_Usun+=Event_Usun;
                if(Event_Dodaj!=null)Event_Dodaj(obj, null);
            }
        }




    }
}
