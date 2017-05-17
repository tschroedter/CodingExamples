#pragma once
#include "ISet.h"
#include "ISets.h"
#include "Container.h"

namespace Tennis
{
    namespace Logic
    {
        class Sets
                : public Container<ISet>
                  , public ISets
        {
        public:
            Sets ( const Hypodermic::FactoryWrapper<ISet>& factory_wrapper )
                : Container<ISet> ( factory_wrapper )
            {
            }

            ISet_Ptr create_new_set () override;
            ISet_Ptr get_current_set () const override;
            ISet_Ptr get_set_at_index ( const size_t index ) const override;
            size_t get_number_of_sets () const override;
        };
    };
};
