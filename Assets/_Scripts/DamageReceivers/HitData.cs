﻿using UnityEngine;

namespace _Scripts.DamageReceivers
{
    public class HitData
    {
        public float damage;
        public Vector2 hitPoint;
        public IHurtBox hurtBox;
        public IHitDetector hitDetector;

        public bool Validate()
        {
            if (hurtBox != null)
            {
                if (hurtBox.CheckHit(this))
                {
                    if (hurtBox.HurtResponder == null || hurtBox.HurtResponder.CheckHit(this))
                    {
                        if (hitDetector.HitResponder == null || hitDetector.HitResponder.CheckHit(this))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }

    public interface IHitResponder
    {
        float Damage { get; }
        public bool CheckHit(HitData data);
        public void Response(HitData data);
    }

    public interface IHurtResponder
    {
        public bool CheckHit(HitData data);
        public void Response(HitData data);
    }

    public interface IHitDetector
    {
        public IHitResponder HitResponder { get; set; }
        public void CheckHit();
    }

    public interface IHurtBox
    {
        public bool Active { get; }
        public GameObject Owner { get; }
        public Transform Transform { get; }
        public IHurtResponder HurtResponder { get; set; }
        public bool CheckHit(HitData hitData);
    }
}