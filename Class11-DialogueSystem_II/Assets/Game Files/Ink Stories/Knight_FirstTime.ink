// Other story sections
INCLUDE Knight_SecondTime

// Variables
VAR visitCount = 0
VAR isHostile = false
VAR hasGivenTrinket = false


// Decide where the story begins on interaction
{visitCount > 0:
    {hasGivenTrinket: 
        -> visit_friendly
      - else:
        { isHostile: -> visit_unfriendly | -> visit_neutral }
    }
  
  - else:
    -> visit_first_time
}


== visit_first_time ==
~ visitCount++

...Oh, you... You're a warrior, eh?

+ [Yes] -> answer_yes
+ [No] -> answer_no

== answer_no ==
I see... Where did you get that armour from then?
+ [I found it]-> found_armour
+ [None of your business] -> not_your_business

== found_armour ==    
~ isHostile = true

Ripped it off some sorry deadman's corpse now, did you?
Coward... Away with you!
+ [Leave] -> END

== not_your_business ==
Alright, alright. Don't put your feet in a puddle.
Just asking a question.
+ [Leave] -> END

== answer_yes ==
I used to be a warrior too, like you.
Then I took an arrow to the knee.
Seems long ago now.
+ [Do you miss it?] -> asked_if_missed
+ [Ignore him] -> ignored

== asked_if_missed ==
Of course! Who wouldn't long for the glory of slaying monsters and evil.
But I look at my youngins and think it's better this way.
Their father may not be a knight, but at least they can grow up with one.
Can I ask a favour of you, warrior?
+ [Of course!] -> accepted_favour
+ [I don't think so] -> declined_favour

== accepted_favour ==
~ hasGivenTrinket = true

This trinket here... it belonged to my old man.
He was a true adventurer. I ask you that you place it on the highest mountain you can find on your travels.
May it bring his soul joy... to once again behold the wonders of the world.
+ [It shall be done]
    You have my gratitude, noble warrior.
        + + [Leave] -> END

== declined_favour ==
I understand. We only just met anyways.
Well, I'll be here if you ever come by again.
+ [Leave] -> END

== ignored ==
Suppose you're not the talkative type.
Well, I'll be here if you ever come by again.
+ [Leave] -> END