import {Channel} from '../../modules/call/components/channel/channel';

export interface Server {
  id: string;
  name: string;
}

export interface GetServersResponse{
  servers: Server[];
}

export interface AddServersRequest{
  name: string;
}

