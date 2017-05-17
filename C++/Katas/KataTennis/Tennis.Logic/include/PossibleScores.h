#pragma once

#include <vector>
#include "Scores.h"

namespace Tennis
{
    namespace Logic
    {
        class PossibleScores
        {
        private:
<<<<<<< HEAD
            const std::vector<std::string> m_scoreAsString = // todo make this static
=======
            const std::vector<std::string> m_scoreAsString =
>>>>>>> Update from private repository
            {
                "Unknown",
                "0",
                "15",
                "30",
                "40",
                "Advantage",
                "AdvantageWon"
            };

        public:

            void set_score ( const Scores score );

            Scores m_current = Love;

            std::string to_string () const;

            void next_score ();

            void previous_score ();
        };
    };
};
