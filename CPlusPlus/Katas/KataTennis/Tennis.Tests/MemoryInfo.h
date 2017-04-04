#pragma once

#include "Windows.h"
#include "psapi.h"
#include <memory>

struct MemoryDetails
{
    bool isValid = false;
    unsigned long peakWorkingSetSize = 0;
    unsigned long workingSetSize = 0;
};

class MemoryInfo
{
private:
    MemoryDetails details_base {};
    MemoryDetails details_zero {};
    MemoryDetails details_one {};
    MemoryDetails pmc_delta {};
    MemoryDetails history[2] {
        details_zero,
        details_one
    };

    int next_index = 0;

    unsigned long deltaPeakWorkingSetSize = 0;
    unsigned long deltaWorkingSetSize = 0;

public:
    MemoryInfo ()
    {
        snapshot ( details_base );

        print_details ( details_base );
    }

    MemoryDetails& getCurrentProcessMemoryCounters ()
    {
        return next_index == 0
                   ? history [ 1 ]
                   : history [ 0 ];
    }

    MemoryDetails& getPreviousProcessMemoryCounters ()
    {
        return next_index == 0
                   ? history [ 0 ]
                   : history [ 1 ];
    }

    static void print_pmc ( const PROCESS_MEMORY_COUNTERS pmc )
    {
        printf ( "\tPageFaultCount:             %u\n", pmc.PageFaultCount );
        printf ( "\tPeakWorkingSetSize:         %u\n", pmc.PeakWorkingSetSize );
        printf ( "\tWorkingSetSize:             %u\n", pmc.WorkingSetSize );
        printf ( "\tQuotaPeakPagedPoolUsage:    %u\n", pmc.QuotaPeakPagedPoolUsage );
        printf ( "\tQuotaPagedPoolUsage:        %u\n", pmc.QuotaPagedPoolUsage );
        printf ( "\tQuotaPeakNonPagedPoolUsage: %u\n", pmc.QuotaPeakNonPagedPoolUsage );
        printf ( "\tQuotaNonPagedPoolUsage:     %u\n", pmc.QuotaNonPagedPoolUsage );
        printf ( "\tPagefileUsage:              %u\n", pmc.PagefileUsage );
        printf ( "\tPeakPagefileUsage:          %u\n", pmc.PeakPagefileUsage );
    }

    static void print_details ( const MemoryDetails details )
    {
        printf ( "\tPeakWorkingSetSize:         %u\n", details.peakWorkingSetSize );
        printf ( "\tWorkingSetSize:             %u\n", details.workingSetSize );
    }

    void calculate_deltas ()
    {
        MemoryDetails& current = getCurrentProcessMemoryCounters();
        MemoryDetails& previous = getPreviousProcessMemoryCounters();

        deltaPeakWorkingSetSize =
                ( current.peakWorkingSetSize - details_base.peakWorkingSetSize )
                - ( previous.peakWorkingSetSize - details_base.peakWorkingSetSize );

        deltaWorkingSetSize =
                ( current.workingSetSize - details_base.workingSetSize )
                - ( previous.workingSetSize - details_base.workingSetSize );
    }

    void print_delta () const
    {
        printf ( "\tPeakWorkingSetSize:         %u\n", deltaPeakWorkingSetSize );
        printf ( "\tWorkingSetSize:             %u\n", deltaWorkingSetSize );
    }

    void snapshot ()
    {
        MemoryDetails& details = history [ next_index ];

        snapshot ( details );

        next_index = ( next_index + 1 ) % 2;
    }

    // To ensure correct resolution of symbols, add Psapi.lib to TARGETLIBS
    // and compile with -DPSAPI_VERSION=1
    static void snapshot ( MemoryDetails& details )
    {
        DWORD processID = GetCurrentProcessId();
        HANDLE hProcess;

        // Print the process identifier.
        printf ( "\nProcess ID: %u\n", processID );

        // Print information about the memory usage of the process.

        hProcess = OpenProcess (
                                PROCESS_QUERY_INFORMATION |
                                                         PROCESS_VM_READ,
                                                         FALSE, processID );

        if ( NULL == hProcess )
            return;

        PROCESS_MEMORY_COUNTERS pmc {};

        if ( GetProcessMemoryInfo ( hProcess, &pmc, sizeof( pmc ) ) )
        {
            details.isValid = true;
            details.peakWorkingSetSize = pmc.PeakWorkingSetSize;
            details.workingSetSize = pmc.WorkingSetSize;
        }
        else
        {
            details.isValid = true;
            details.peakWorkingSetSize = pmc.PeakWorkingSetSize;
            details.workingSetSize = pmc.WorkingSetSize;
        }

        print_pmc ( pmc );

        CloseHandle ( hProcess );
    }
};
