#include "include/PossibleScores.h"
#include "include/GameScore.h"
#include "include/Scores.h"

namespace Tennis
{
    namespace Logic
    {
        std::string GameScore::to_string () const
        {
            return m_score.to_string();
        }

        void GameScore::won_point ()
        {
            m_score.next_score();
        }

        void GameScore::lost_point ()
        {
            m_score.previous_score();
        }

        Scores GameScore::get_score () const
        {
            return m_score.m_current;
        }
    };
};
