using System;
using Verse;
using RimWorld;
namespace FlameWeapons
{
    public class BulletIncendiary : Bullet
    {
        protected override void Impact(Thing hitThing)
        {
            base.Impact(hitThing);
            if (hitThing != null)
            {
                hitThing.TryAttachFire(0.2f);
            }
            else
            {
                GenSpawn.Spawn(ThingDef.Named("FilthFuel"), Position, Map);
                FireUtility.TryStartFireIn(Position, Map, 0.2f);
            }
            MoteMaker.MakeStaticMote(Position, Map, ThingDefOf.Mote_ShotFlash, 6f);
            MoteMaker.ThrowMicroSparks(Position.ToVector3Shifted(), Map);
        }
    }
}
