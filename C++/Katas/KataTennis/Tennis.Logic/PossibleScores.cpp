#include <cassert>
#include "include/PossibleScores.h"
#include "include/Scores.h"

namespace Tennis
{
    namespace Logic
    {
        void PossibleScores::set_score ( const Scores score )
        {
            m_current = score;
        }

        std::string PossibleScores::to_string () const
        {
            size_t index = static_cast<size_t> ( m_current );

            assert(index >= 0 && index < Max_Score);

            return m_scoreAsString [ index ];
        }

        void PossibleScores::next_score ()
        {
            if ( m_current != Unknown &&
                m_current < AdvantageWon )
            {
                m_current = static_cast<Scores> ( m_current + 1 );
            }

            // todo error ?
        }

        void PossibleScores::previous_score ()
        {
            switch ( m_current )
            {
                case Unknown :
                case Love :
                case Fifteen :
                case Thirty :
                case Forty :
                case AdvantageWon :
                    break;
                case Advantage :
                    m_current = Forty;
                    break;
                default :
                    // todo error ?
                    break;
            }
        }
    };
};
