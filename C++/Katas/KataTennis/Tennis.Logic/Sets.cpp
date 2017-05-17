#include "include/Sets.h"

namespace Tennis
{
    namespace Logic
    {
        ISet_Ptr Sets::create_new_set ()
        {
            auto new_set = new_item();

            new_set->initialize();

            return new_set;
        }

        ISet_Ptr Sets::get_current_set () const
        {
            return get_current_item();
        }

        ISet_Ptr Sets::get_set_at_index ( const size_t index ) const
        {
            return ( *this ) [ index ];
        }

        size_t Sets::get_number_of_sets () const
        {
            return get_length();
        }
    };
};
