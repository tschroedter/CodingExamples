#pragma once
#include "PossibleScores.h"
#include "IGameScore.h"

namespace Tennis
{
    namespace Logic
    {
<<<<<<< HEAD
        class GameScore // todo continue
=======
        class GameScore
>>>>>>> Update from private repository
                : public IGameScore
        {
        private:
            PossibleScores m_score {};
        public:
            GameScore ( Scores score = Love )
            {
                m_score.set_score ( score );
            }

            ~GameScore ()
            {
            }

<<<<<<< HEAD
            std::string to_string() const override;

            void won_point() override;

            void lost_point() override;

            Scores get_score() const override;
=======
            std::string to_string () const override;

            void won_point () override;

            void lost_point () override;

            Scores get_score () const override;
>>>>>>> Update from private repository
        };
    };
};
