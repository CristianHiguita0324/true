import React from 'react';
import TicketsGrid from '../../../transportBalance/cutOff/components/ticketsGrid.jsx';

export default class OfficialLogisticsGrid extends React.Component {
    render() {
        return (
            <>
                <TicketsGrid {...this.props} />
            </>
        );
    }
}
