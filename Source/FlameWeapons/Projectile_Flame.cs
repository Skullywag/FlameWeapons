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
                GenSpawn.Spawn(ThingDef.Named("FilthFuel"), base.Position);
                FireUtility.TryStartFireIn(base.Position, 0.2f);
            }
            MoteMaker.MakeStaticMote(this.Position, ThingDefOf.Mote_ShotFlash, 6f);
            MoteMaker.ThrowMicroSparks(base.Position.ToVector3Shifted());
        }
    }
}
