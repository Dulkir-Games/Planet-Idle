# Core loop

Planet Idle is an idle game about growing a planet by pulling in space debris, spending accumulated mass on upgrades, and eventually reaching a prestige milestone where the planet transforms into something new.

This document describes the intended gameplay loop. Numbers and exact tuning are TBD; the goal is to capture *what the player does* and *why it feels good*.

---

## One-sentence pitch

Watch debris drift toward your planet, break up the pieces you can't swallow yet, spend mass to grow stronger and shrink until you hit critical mass and choose what your world becomes next.

---

## Core fantasy

You are a growing celestial body in a field of drifting debris. Gravity is your tool. Mass is your currency and your body. Upgrades make you more capable and physically smaller. Eventually you reach a tipping point where the run ends or evolves through prestige.

---

## Primary resources

| Resource | Role |
|----------|------|
| **Mass** | Currency for upgrades. Also represents the planet's physical size on screen. |
| **Debris** | Incoming objects of varying size. Absorbing them increases mass. |

### Mass as currency and body

Buying upgrades **costs mass** and **shrinks the planet**. This is the central trade-off:

- **Larger planet**: easier to collide with debris, can swallow bigger chunks, slower or weaker pull depending on tuning.
- **Smaller planet**: harder to hit things directly, but upgrades make you more efficient; visually reads as "dense" and hungry.

The player should feel this tension without doing math: spend to get stronger, grow by eating, decide when to bulk up vs. invest.

---

## Session loop

```
Debris spawns → Gravity pulls debris in → Planet absorbs compatible debris (+mass)
      ↑                                              |
      |                                              ↓
  More spawns ←── Upgrades ←── Spend mass (planet shrinks)
```

1. Debris appears in the playspace (rate and size distribution upgradeable).
2. Gravity pulls debris toward the planet (strength and shape upgradeable).
3. Debris the planet can absorb merges into it, increasing mass and visible size.
4. The player spends mass on upgrades, shrinking the planet while gaining power.
5. Repeat until a prestige condition is met.

---

## Debris and assimilation

Debris comes in different sizes. The planet can only absorb pieces **smaller than a threshold relative to its radius**. One simple rule, no spreadsheet.

| Size | Behavior |
|------|----------|
| Small enough | Pulled in and absorbed automatically on contact. |
| Too large | Bounces off, orbits, or drifts past unless broken down first. |

Breaking debris into smaller chunks is the main **manual action** in early game.

---

## Upgrades

Upgrades are purchased with mass. Each purchase shrinks the planet.

| Upgrade | Effect | Notes |
|---------|--------|-------|
| **More incoming debris** | Increases spawn rate and/or variety. | Feeds the loop; primary "income" lever. |
| **Stronger gravity** | Increases pull strength and/or capture radius. | Makes assimilation easier; core feel upgrade. |
| **Localized gravity well** | Adds a focal pull point instead of uniform gravity. | Fewer simulation nodes globally → room for more spawns. Player trades even coverage for density and performance. Benefit should be obvious: stronger pull in a zone you care about. |
| **Automatic rockets** | Periodically breaks large debris into smaller chunks. | Primary automation. Manual breaking early → rockets later. "Blow it up so you can eat it." |

Future upgrades can branch from these; v0.1 only needs gravity, spawns, and one breaking mechanic.

---

## Manual → automated progression

Aligned with [design pillars](pillars.md):

1. **Early**: player manually triggers breaking on oversized debris (click, aim, or simple target).
2. **Mid**: upgrades improve manual breaking (faster, larger targets, cooldown).
3. **Late**: automatic rockets handle breaking; player focuses on upgrade choices and placement (e.g. gravity wells).

Long-term play should skew toward **decisions**, not repeated chores.

---

## Prestige

When the planet reaches **critical mass**, the run ends with a player choice. Both paths reset run progress but grant different meta rewards (exact currencies TBD).

### Path A: Ignition (star)

The planet collapses and ignites. Fantasy: passive output, radiance, eventual solar-system scale.

- **Meta hook**: star type, passive bonuses, orbiting bodies later.
- **Tone**: growth, expansion, sustained passives.

### Path B: Cold death

The planet fails to ignite and freezes out. Fantasy: harvest the corpse for something valuable.

- **Meta hook**: remnant matter, entropy, or similar harvest currency.
- **Tone**: deliberate sacrifice, different build identity.

Prestige is a **north star**, not a v0.1 requirement. The core loop must be fun for 20–30 minutes before prestige matters.

### Shrinking vs. critical mass

Upgrades shrink the planet while critical mass requires growing large enough to transform. Expect a **bulk-up phase** before prestige: the player stops spending (or spends selectively) and eats debris until the planet is big enough to prestige. This should feel like a deliberate choice, not a punishment for upgrading.

---

## UI layout (sketch)

| Area | Content |
|------|---------|
| **Center** | The planet, main visual focus. Debris motion plays out here. |
| **Left** | Upgrade list and purchase buttons. |
| **Top right** | Current mass, planet size indicator, income rate. |
| **Bottom right** | Prestige progress toward critical mass (hidden or minimal until relevant). |

Visual satisfaction is a pillar: motion, growth, impacts, and breaking should read clearly on a second monitor.

---

## v0.1 scope

Ship the smallest loop that validates the fantasy:

- [ ] Planet in center; visible size scales with mass.
- [ ] Debris spawns and drifts; gravity pulls it in.
- [ ] Size threshold for absorption; oversized debris cannot merge.
- [ ] One manual break action on large debris.
- [ ] Two upgrades: stronger gravity, more incoming debris.
- [ ] Upgrades cost mass and shrink the planet.

**Out of scope for v0.1:** prestige, gravity wells, automatic rockets, offline progress, meta currencies.

---
